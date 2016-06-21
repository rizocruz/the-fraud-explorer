<?php

/*
 * The Fraud Explorer
 * http://www.thefraudexplorer.com/
 *
 * Copyright (c) 2016 The Fraud Explorer
 * email: customer@thefraudexplorer.com
 * Licensed under GNU GPL v3
 * http://www.thefraudexplorer.com/License
 *
 * Date: 2016-05-31 15:12:41 -0500 (Wed, 31 May 2016)
 * Revision: v0.9.5-beta
 *
 * Description: Code for refresh agents table dinamically (dashboard) using AJAX
 */

session_start();

include "inc/check-access.php";
require 'vendor/autoload.php';
include "inc/global-vars.php";
include "inc/open-db-connection.php";
include "inc/agent_methods.php";
include "inc/check_perm.php";
include "inc/elasticsearch.php";

if(empty($_SESSION['connected']))
{
 	header ("Location: ".$serverURL);
 	exit;
}

$_SESSION['id_uniq_command']=null;

/* Order the dashboard agent list */

$order = mysql_query("SELECT agent,heartbeat, now() FROM t_agents");

if ($row = mysql_fetch_array($order))
{
	do
	{
		if(isConnected($row["heartbeat"], $row[2])) 
                {
			$sendquery="UPDATE t_agents SET status='active' where agent='" .$row["agent"]. "'"; 
			queryOrDie($sendquery);
                }
                else 
                { 
                        $sendquery="UPDATE t_agents SET status='inactive' where agent='" .$row["agent"]. "'";
                	queryOrDie($sendquery);
		}
	}
	while ($row = mysql_fetch_array($order));
}

/* Elasticsearch querys for fraud triangle counts and score */

$client = Elasticsearch\ClientBuilder::create()->build();
$configFile = parse_ini_file("config.ini");
$ESindex = $configFile['es_words_index'];
$ESalerterIndex = $configFile['es_alerter_index'];
$fraudTriangleTerms = array('r'=>'rationalization','o'=>'opportunity','p'=>'pressure','c'=>'custom');

/* Show main table and telemetry with the agent list */

if ($userConnected != 'admin') $result_a = mysql_query("SELECT agent,heartbeat, now(), system, version, status, name, owner, gender FROM t_agents WHERE owner='".$userScope."' ORDER BY FIELD(status, 'active','inactive'), agent ASC");
else $result_a = mysql_query("SELECT agent,heartbeat, now(), system, version, status, name, owner, gender FROM t_agents ORDER BY FIELD(status, 'active','inactive'), agent ASC");
$count_all = mysql_fetch_assoc(mysql_query("SELECT count(*) AS total FROM t_agents"));
$count_online = mysql_fetch_assoc(mysql_query("SELECT count(*) AS total FROM t_agents WHERE status='active'"));
$count_offline = mysql_fetch_assoc(mysql_query("SELECT count(*) AS total FROM t_agents WHERE status='inactive'"));

if ($row_a = mysql_fetch_array($result_a))
{
 	/* Telemetry */ 

 	echo '<div class="content">';
	echo '<center><div align="center" width="100%" style="width: 1316px; background:#e8eaeb; border:1px solid #d3d3d3; -moz-box-shadow: 0 0 4px rgba(0, 0, 0, 0.2); -webkit-box-shadow: 0 0 4px rgba(0, 0, 0, 0.2);"><p>';
	echo '<font face="Verdana" size="2px">';
	echo '<label for="search">';
	echo '</label>';
	echo '<br><br><b style="font-family: \'FFont\', sans-serif; font-size:12px; color: #474747;">SEARCH </b>';
	echo '<input type="text" id="search" autocomplete="off" placeholder=":find data in main dashboard ..." style="width: 60%; padding: 5px; border: solid 2px #c9c9c9; -webkit-transition: border 0.3s; -moz-transition: border 0.3s; -o-transition: border 0.3s; transition: border 0.3s;"/>';
        echo '<b style="font-family: \'FFont\', sans-serif; font-size:12px; color: #474747;"> TELEMETRY </b>';
        echo '<input type="text" id="telemetry" autocomplete="off" disabled placeholder=" ';
        echo str_pad($count_all['total'], 4, "0", STR_PAD_LEFT).' agents registered, '.str_pad($count_online['total'], 4, "0", STR_PAD_LEFT).' online, '.str_pad($count_offline['total'], 4, "0", STR_PAD_LEFT);
	echo ' offline" style="width: 27%; padding: 5px; border: solid 2px #c9c9c9; -webkit-transition: border 0.3s; -moz-transition: border 0.3s; -o-transition: border 0.3s; transition: border 0.3s;"/>';
	echo '<br><br></font>';
	echo '</p></div></center><br>';

	/* Main Table */

	echo '<table summary="Dashboard table" id="tblData" class="target">';
 	echo '<thead><tr><th class="osth"><b>OS</b></th><th class="agentth"><b>AGENT</b></th>
	<th class="compth"><b>GROUP</b></th><th class="verth"><b>VER</b></th><th class="stateth"><b>STT</b></th><th class="lastth"><b>LAST</b></th>
	<th class="countpth"><b>P</b></th><th class="countoth"><b>O</b></th><th class="countrth"><b>R</b></th><th class="countcth"><b>C</b></th><th class="scoreth"><b>SCORE</b></th>
	<th class="specialth"><b>CMD</b></th><th class="specialth"><b>DEL</b></th><th class="specialth"><b>SET</b></th></tr></thead><tbody>';

 	do 
 	{
  		$agent_enc=base64_encode(base64_encode($row_a["agent"]));

		/* Operating system */

 	 	echo '<tr>';
  		echo '<td class="ostd"><img src="'. getImgSist($row_a["system"]) .'"align="center"/><br>'. getTextSist($row_a["system"]) .'</td>';

		/* Gender identification */

		if ($row_a["name"] == NULL) 
		{
			echo '<td class="agenttd">';
			if ($row_a["gender"] == "male") echo '<img src="images/male-agent.gif" style="vertical-align:middle;" width="40px" height="40px">&nbsp;&nbsp;' . $row_a["agent"] . '</td>';
			else if ($row_a["gender"] == "female") echo '<img src="images/female-agent.gif" style="vertical-align:middle;" width="40px" height="40px">&nbsp;&nbsp;' . $row_a["agent"] . '</td>';
			else echo '<img src="images/male-agent.gif" style="vertical-align:middle;" width="40px" height="40px">&nbsp;&nbsp;' . $row_a["agent"] . "</td>";
		}
		else
		{
			echo '<td class="agenttd">';
			if ($row_a["gender"] == "male") echo '<img src="images/male-agent.gif" style="vertical-align:middle;" width="40px" height="40px">&nbsp;&nbsp;' . $row_a["name"] . '</td>';
			else if ($row_a["gender"] == "female") echo '<img src="images/female-agent.gif" style="vertical-align:middle;" width="40px" height="40px">&nbsp;&nbsp;' . $row_a["name"] . '</td>';
			else echo '<img src="images/male-agent.gif" style="vertical-align:middle;" width="40px" height="40px">&nbsp;&nbsp;' . $row_a["name"] . '</td>';
		}

		/* Company, department or group */

		if ($row_a["owner"] == NULL) echo '<td class="comptd">NYET</td>';
                else echo '<td class="comptd">' . $row_a["owner"] . "</td>";

		/* Agent software version */

 	 	echo '<td class="vertd">' .$row_a["version"] .'</td>';

		/* Agent status */

  		if($row_a["status"] == "active") 
		{ 
			echo '<td class="statetd"><img src="images/agentOnline.svg"></td>'; 
		}
  		else 
		{ 
			echo '<td class="statetd"><img src="images/agentOffline.svg"/></td>'; 
		}

		/* Last connection to the server */

  		echo '<td class="lasttd">'.str_replace(array("-"),array("/"),$row_a["heartbeat"]).'&nbsp;</td>';
  		$result_b=mysql_query("SELECT command FROM t_".str_replace(array("."),array("_"),$row_a["agent"])." order by date desc limit 1");
  		$row_b = mysql_fetch_array($result_b);

		echo '<div id="fraudCounterHolder"></div>';

		/* Fraud triangle counts and score */
		
		$matchesRationalization = countFraudTriangleMatches($row_a["agent"], $fraudTriangleTerms['r'], $configFile['es_alerter_index']);
                $matchesOpportunity = countFraudTriangleMatches($row_a["agent"], $fraudTriangleTerms['o'], $configFile['es_alerter_index']);
                $matchesPressure = countFraudTriangleMatches($row_a["agent"], $fraudTriangleTerms['p'], $configFile['es_alerter_index']);
                $matchesCustom = countFraudTriangleMatches($row_a["agent"], $fraudTriangleTerms['c'], $configFile['es_alerter_index']);

		if ($matchesRationalization['hits']['total'] != 0)
		{
			$GLOBALS['arrayPosition'] = 0;
			getArrayData($matchesRationalization, "matchNumber", 'numberOfRMatches');
        		$countRationalization = array_sum($GLOBALS['numberOfRMatches']);
		} 
		else $countRationalization = 0;

  	        if ($matchesOpportunity['hits']['total'] != 0) 
		{
			$GLOBALS['arrayPosition'] = 0;
			getArrayData($matchesOpportunity, "matchNumber", 'numberOfOMatches');
			$countOpportunity = array_sum($GLOBALS['numberOfOMatches']);
		}
		else $countOpportunity = 0; 

                if ($matchesPressure['hits']['total'] != 0) 
		{
			$GLOBALS['arrayPosition'] = 0;
			getArrayData($matchesPressure, "matchNumber", 'numberOfPMatches');
			$countPressure = array_sum($GLOBALS['numberOfPMatches']);
		}
		else $countPressure = 0;

		if ($matchesCustom['hits']['total'] != 0) 
		{
			$GLOBALS['arrayPosition'] = 0;
			getArrayData($matchesCustom, "matchNumber", 'numberOfCMatches');
			$countCustom = array_sum($GLOBALS['numberOfCMatches']);
		}
		else $countCustom = 0;
		
		echo '<td class="countptd">'.$countPressure.'</td>';
		echo '<td class="countotd">'.$countOpportunity.'</td>';
		echo '<td class="countrtd">'.$countRationalization.'</td>';
		echo '<td class="countctd">'.$countCustom.'</td>';
		$score=($countPressure+$countOpportunity+$countRationalization+$countCustom)/4;
		echo '<td class="scoretd"><b>'.$score.'</b></td>';  

		unset($GLOBALS['numberOfRMatches']);
		unset($GLOBALS['numberOfOMatches']);
		unset($GLOBALS['numberOfPMatches']);
		unset($GLOBALS['numberOfCMatches']);

		/* Agent selection for command retrieval */

		if(isConnected($row_a["heartbeat"], $row_a[2]) && $userPermissions != "view")
  		{
			if(isset($_SESSION['agentchecked']))
                        {
				if($_SESSION['agentchecked'] == $row_a["agent"]) echo '<td class="specialtd"><a href="mainMenu?agent='.$agent_enc.'"><img src="images/cmd-ok.svg" onmouseover="this.src=\'images/cmd-mo-ok.svg\'" onmouseout="this.src=\'images/cmd-ok.svg\'" alt="" title="" /></a></td>';
				else echo '<td class="specialtd"><a href="mainMenu?agent='.$agent_enc.'"><img src="images/cmd.svg" onmouseover="this.src=\'images/cmd-mo.svg\'" onmouseout="this.src=\'images/cmd.svg\'" alt="" title="" /></a></td>';  
			}
			else echo '<td class="specialtd"><a href="mainMenu?agent='.$agent_enc.'"><img src="images/cmd.svg" onmouseover="this.src=\'images/cmd-mo.svg\'" onmouseout="this.src=\'images/cmd.svg\'" alt="" title="" /></a></td>';
		}
  		else
  		{	if(isset($_SESSION['agentchecked']))
			{	
				if($_SESSION['agentchecked'] == $row_a["agent"]) echo '<td class="specialtd"><img src="images/cmd-ok.svg" onmouseover="this.src=\'images/cmd-mo-ok.svg\'" onmouseout="this.src=\'images/cmd-ok.svg\'" alt="Agent down" title="Agent down" /></td>';
   				else echo '<td class="specialtd"><img src="images/cmd.svg" onmouseover="this.src=\'images/cmd-mo.svg\'" onmouseout="this.src=\'images/cmd.svg\'" alt="Agent down" title="Agent down" /></td>';
			}
			else echo '<td class="specialtd"><img src="images/cmd.svg" onmouseover="this.src=\'images/cmd-mo.svg\'" onmouseout="this.src=\'images/cmd.svg\'" alt="Agent down" title="Agent down" /></td>'; 
 		}

		/* Option for delete the agent */

		if($userPermissions != "view")
		{
  			echo '<td class="specialtd"><a data-href="deleteAgent?agent='.$agent_enc.'" data-toggle="modal" data-target="#confirm-delete" href="#"><img src="images/delete-button.svg" onmouseover="this.src=\'images/delete-button-mo.svg\'" onmouseout="this.src=\'images/delete-button.svg\'" alt="" title=""/></a></td>';	
		}
		else
		{
			echo '<td class="specialtd"><img src="images/delete-button.svg" onmouseover="this.src=\'images/delete-button-mo.svg\'" onmouseout="this.src=\'images/delete-button.svg\'" alt="" title=""/></a></td>';
		}

		/* Agent setup option */

		if($userPermissions != "view")
                {
			echo '<td class="specialtd"><a href="setupAgent?agent='.$agent_enc.'"><img src="images/setup.svg" onmouseover="this.src=\'images/setup-mo.svg\'" onmouseout="this.src=\'images/setup.svg\'" alt="" title=""/></a></td>';
		}
		else
		{
			echo '<td class="specialtd"><img src="images/setup.svg" onmouseover="this.src=\'images/setup-mo.svg\'" onmouseout="this.src=\'images/setup.svg\'" alt="" title=""/></a></td>';
		}

  		echo '</tr>';
 	} 
 	while ($row_a = mysql_fetch_array($result_a));
 	echo '</tbody></table>';
 	echo '</div>';
}

?>

<!-- Modal for delete dialog -->

<script>
 	$('#confirm-delete').on('show.bs.modal', function(e) {
  	$(this).find('.danger').attr('href', $(e.relatedTarget).data('href'));
 	}); 
</script>

<!-- Modal for setup dialog -->

<script>
        $('#confirm-setup').on('show.bs.modal', function(e) {
        $(this).find('.danger').attr('href', $(e.relatedTarget).data('href'));
        });
</script>

<!-- Table sorting -->

<script>
	$(document).ready(function() 
    	{ 
        	$("#tblData").tablesorter(); 
    	} 
	); 
</script>

<!-- Table search -->

<script type="text/javascript">
	$(document).ready(function()
	{
		$('#search').keyup(function()
		{
			searchTable($(this).val());
		});
	});
		
	function searchTable(inputVal)
	{
		var table = $('#tblData');

		table.find('tr').each(function(index, row)
		{
			var allCells = $(row).find('td');
					
			if(allCells.length > 0)
			{
				var found = false;
				
				allCells.each(function(index, td)
				{
					var regExp = new RegExp(inputVal, 'i');
					
					if(regExp.test($(td).text()))
					{
						found = true;
						return false;
					}
				});
						
				if(found == true)$(row).show();else $(row).hide();
			}
		});
	}
</script>

<!-- Center modal dialogs vertically -->

<script>
	$(function() 
	{
    		function reposition() 
		{
        		var modal = $(this),
            		dialog = modal.find('.modal-dialog');
        		modal.css('display', 'block');
        		dialog.css("margin-top", Math.max(0, ($(window).height() - dialog.height()) / 2));
    		}
    	
		$('.modal').on('show.bs.modal', reposition);
    		$(window).on('resize', function() 
		{
        		$('.modal:visible').each(reposition);
    		});
	});
</script>
