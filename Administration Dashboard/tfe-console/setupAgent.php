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
 * Description: Code for setup agent
 */

include "inc/check-access.php";
session_start();

include "inc/check_perm.php";
include "inc/global-vars.php";

if ($userPermissions != "subadmin") 
{
	if ($userConnected == "admin") $admin="yes";
	else header ("Location: mainMenu");
}

if(empty($_SESSION['connected']))
{
 	header ("Location: ".$serverURL);
 	exit;
}

error_reporting(0);
include "inc/open-db-connection.php";

function filter($variable)
{
 	return addcslashes(mysql_real_escape_string($variable),',-<>"');
}

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Setup agent</title>
	<meta http-equiv="X-Frame-Options" content="deny">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

	<!-- JQuery 11 inclusion -->

 	<script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>

 	<!-- Code for Tooltipster -->

 	<link rel="stylesheet" type="text/css" href="css/tooltipster.css"/>
 	<script type="text/javascript" src="js/jquery.tooltipster.js"></script>
 	<link rel="stylesheet" type="text/css" href="css/bootstrap.css">
 	<script src="js/bootstrap.js"></script>

 	<!-- JS functions -->

 	<script type="text/javascript" src="js/setupAgent.js"></script>

 	<link rel="stylesheet" type="text/css" href="css/setupAgent.css" media="screen" />
</head>

<body>
	<div align="center" width="100%">
		
		<div style="width:100%; height:68px; border:1px solid gray; border-top-style: none; border-right-style:none; border-bottom-style: none; 
		 border-left-style: none; background-color: #e8eaeb;"><br>
			<center>
			<div style="width:1316px; text-align: left; background-color: #e8eaeb;">
				<p style="text-align: left; width: 100%; font-family: 'FFont', sans-serif; font-size:26px; color:black;">
				<img style="vertical-align:middle" src="images/nftop.png" width=50 height=50><span style="vertical-align: middle;">&nbsp;<b>TFE</b>&nbsp;&reg; The Fraud Explorer</span></p>
			</div>
			</center>
		</div>
		<br>

		<div style="width:1316px; opacity: 0.9;"><p align=right style="font-family: 'FFont', sans-serif; font-size:22px; color: #474747;">Agent setup from

			<?php

			$agent_id = base64_decode(base64_decode($_GET['agent']));
			$result_a = mysql_query(sprintf("SELECT agent, name, gender FROM t_agents WHERE agent = '%s'", $agent_id));
			if ($row_a = mysql_fetch_array($result_a))
			{	
				if ($row_a["name"] == NULL) 
				{
			 		if ($row_a["gender"] == "male") echo '<img src="images/male-agent.gif" style="vertical-align:middle;" width="29px" height="29px" class="tooltip" 
			 		title="No name yet ('. $agent_id .')"/>';

			 		else if ($row_a["gender"] == "female") echo '<img src="images/female-agent.gif" style="vertical-align:middle;" width="29px" height="29px" class="tooltip" 
                         		title="No name yet ('. $agent_id .')"/>';

  			 		else echo '<img src="images/male-agent.gif" style="vertical-align:middle;" width="29px" height="29px" class="tooltip"
                         		title="No name yet ('. $agent_id .')"/>';
				}
				else 
				{
					if ($row_a["gender"] == "male") echo '<img src="images/male-agent.gif" style="vertical-align:middle;" width="29px" height="29px" class="tooltip"
                                        title="' . $row_a['name'] .' ('. $agent_id .')"/>';

					else if ($row_a["gender"] == "female") echo '<img src="images/female-agent.gif" style="vertical-align:middle;" width="29px" height="29px" class="tooltip"
                                        title="' . $row_a['name'] .' ('. $agent_id .')"/>';

					else echo '<img src="images/male-agent.gif" style="vertical-align:middle;" width="29px" height="29px" class="tooltip"
                                        title="' . $row_a['name'] .' ('. $agent_id .')"/>';
				}
			}

			echo '&nbsp;|';

			?>

			<a href="mainMenu"><img style="vertical-align:middle" src="images/mainMenu.svg" border="none" class="tooltip" title="Dashboard"/></a>

			<?php
				$link_url="eraseCommands.php";
				echo '<a href="#" class="reset-xml-button" id="'.$link_url.'"><img style="vertical-align:middle" src="images/clearXML.svg" class="tooltip" title="Reset command queue"></a>';
			?>

			<a href="logout"><img style="vertical-align:middle" src="images/logout.svg" border="none" class="tooltip" title="Secure logout"/></a>

			<?php
 				$agent_dec=base64_decode(base64_decode($_GET['agent']));
 				$agent_enc=filter($_GET['agent']);
 				echo '<a href="setupAgent?agent=' . filter($_GET['agent']) . '"' . '><img style="vertical-align:middle" src="images/refreshPage.svg" border="none" class="tooltip" 
				title="Refresh page"/></a></td></tr></table><br>';
			?>
 			</p>
		</div>
		<br>

		<table summary="Setup">
		<thead>
			<tr>
				<th class="basicth""><b>BASIC CONFIGURATION</b></th>
				<th class="advancedth"><b>ADVANCED CONFIGURATION</b></th>		
			</tr>
		</thead>
		<tbody>
			<tr>
				<td class="basictd">Specify/change the alias name of the agent<br><br>
     					<form id="form1" name="form1" method="post" action="<?php echo 'setupAgentParameters?agent='.$agent_enc.'&alias=yes' ?>">
       						<input type="text" name="alias" id="alias" autocomplete="off" placeholder=":alias here <?php 
                                                $aliasquery = mysql_query(sprintf("SELECT name FROM t_agents WHERE agent='%s'",$agent_dec)); $alias = mysql_fetch_array($aliasquery);
                                                if ($alias[0] == NULL) echo '(current value: Not alias yet)'; 
						else echo '(current value: '.$alias[0].')'; ?>" style="width:540px; height: 30px; 
						padding: 5px; border: solid 2px #c9c9c9; -webkit-transition: border 0.3s; -moz-transition: border 0.3s; -o-transition: border 0.3s; 
						transition: border 0.3s;">
       							
						<input type="submit" name="aliasok" value="Save alias" style="width:80px; height: 30px">
    					</form> 
				</td>
			</tr>		
			<tr>
				<td class="basictd">Set the owner/group name of the agent<br><br>
                                        <form id="form2" name="form2" method="post" action="<?php echo 'setupAgentParameters?agent='.$agent_enc.'&owner=yes' ?>">
                                                <input type="text" name="owner" id="owner" autocomplete="off" placeholder=":owner/company name here <?php
                                                $ownerquery = mysql_query(sprintf("SELECT owner FROM t_agents WHERE agent='%s'",$agent_dec)); $owner = mysql_fetch_array($ownerquery);
                                                if ($owner[0] == NULL) echo '(current value: Not company yet)';
                                                else echo '(current value: '.$owner[0].')'; ?>" style="width:540px; height: 30px; 
                                                padding: 5px; border: solid 2px #c9c9c9; -webkit-transition: border 0.3s; -moz-transition: border 0.3s; -o-transition: border 0.3s; 
                                                transition: border 0.3s;"> 
                                                        
                	                        <input type="submit" name="ownerok" value="Set owner" style="width:80px; height: 30px">
                                        </form>
                                </td>
			</tr>
			 <tr>
                                <td class="basictd">Set the gender of the agent<br><br>
                                        <form id="form2" name="form2" method="post" action="<?php echo 'setupAgentParameters?agent='.$agent_enc.'&gender=yes' ?>">
                                                <input type="text" name="gender" id="gender" autocomplete="off" placeholder=":gender here (male/female) <?php
                                                $genderquery = mysql_query(sprintf("SELECT gender FROM t_agents WHERE agent='%s'",$agent_dec)); $gender = mysql_fetch_array($genderquery);
                                                if ($gender[0] == NULL) echo '(current value: Not gender yet)';
                                                else echo '(current value: '.$gender[0].')'; ?>" style="width:540px; height: 30px;
                                                padding: 5px; border: solid 2px #c9c9c9; -webkit-transition: border 0.3s; -moz-transition: border 0.3s; -o-transition: border 0.3s;
                                                transition: border 0.3s;">

                                                <input type="submit" name="genderok" value="Set genre" style="width:80px; height: 30px">
                                       </form>
                                </td>
                        </tr>
		</tbody>		
		</table>

	</div>		

	<div align="center" id="tableHolderXML"></div>

	<div id="includedFooterContent"></div><br>&nbsp;<br>&nbsp;

	<?php
		include "inc/close-db-connection.php";
	?>

</body>
</html>
