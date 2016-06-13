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
 * Date: 2016-06-31 15:12:41 -0500 (Wed, 31 Jun 2016)
 * Revision: v0.9.6-beta
 *
 * Description: Code for dashboard
 */

include "inc/check-access.php";
session_start();

if(empty($_SESSION['connected']))
{
 header ("Location: index");
 exit;
}

include "inc/check_perm.php";
error_reporting(0);

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Application dashboard</title>
	<meta http-equiv="X-Frame-Options" content="deny">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

	<!-- JQuery 11 inclusion -->

	<script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>

	<!-- Code for Tooltipster -->

	<link rel="stylesheet" type="text/css" href="css/tooltipster.css"/>
	<script type="text/javascript" src="js/jquery.tooltipster.js"></script>

	<!-- JS functions -->

	<script type="text/javascript" src="js/mainMenu.js"></script>
	
	<!-- Styles and JS for modal dialogs -->

	<link rel="stylesheet" type="text/css" href="css/bootstrap-mainmenu.css">
	<script src="js/bootstrap.js"></script>

	<!-- Finish code for modal dialogs -->

	<link rel="stylesheet" type="text/css" href="css/mainMenu.css" media="screen" />

	<!-- Ajax for capture ENTER key in command line -->

 	<script language="JavaScript" type="text/javascript" src="js/ajax.js"></script>

	<!-- ConsoleJS functions -->

	<script type="text/javascript" src="js/console.js"></script>

	<!-- Table sorting -->

	<script type="text/javascript" src="js/jquery.tablesorter.js"></script> 
</head>
<body>
	<div align="center" width="100%">

		<div style="width:100%; height:68px; border:1px solid gray; border-top-style: none; border-right-style:none; border-bottom-style: none;
                 border-left-style: none; background-color: #e8eaeb;"><br>
                        <center>
                        <div style="width:1316px; background-color: #e8eaeb;">
                                <p style="text-align: left; width: 100%; font-family: 'FFont', sans-serif; font-size:26px; color:black;">
                                <img style="vertical-align:middle" src="images/nftop.png" width=50 height=50><span style="vertical-align: middle;">&nbsp;<b>TFE</b>&nbsp;&reg; The Fraud Explorer</span></p>
                        </div>
                        </center>
                </div>
                <br>

		<div style="width:1316px; opacity: 0.9;"><p align=right style="font-family: 'FFont', sans-serif; font-size:22px; color:black;">Welcome <?php echo $_SESSION['user_con']; ?> - Application dashboard&nbsp;&nbsp;
			<?php 
				include "inc/global-vars.php"; 
				if ($userPermissions != "view" && $userConnected == "admin") echo '<a href="generalSetup"><img style="vertical-align:middle" src="images/generalSetup.svg" border="none" class="tooltip" title="System & user administration"/></a>&nbsp;';
				else echo '<img style="vertical-align:middle" src="images/generalSetup.svg" border="none" class="tooltip" title="System & user administration"/>&nbsp;';
				echo '<a href="mainMenu"><img style="vertical-align:middle" src="images/mainMenu.svg" border="none" class="tooltip" title="Dashboard"/></a>&nbsp;';
				if ($userPermissions != "view") echo '<a href="eraseCommands.php"><img style="vertical-align:middle" src="images/clearXML.svg" class="tooltip" title="Reset command queue"></a>&nbsp;';
				else echo '<img style="vertical-align:middle" src="images/clearXML.svg" class="tooltip" title="Reset command queue">&nbsp;';
				echo '<a href="logout"><img style="vertical-align:middle" src="images/logout.svg" border="none" class="tooltip" title="Secure logout"/></a>&nbsp;';
				echo '<a href="mainMenu"><img style="vertical-align:middle" src="images/refreshPage.svg" border="none" class="tooltip" title="Refresh page"/></a>&nbsp;';
				echo '<a href="'.$analyticsURL.'" target="_blank"><img style="vertical-align:middle" src="images/analytics.svg" border="none" class="tooltip" title="Analytics"/></a>&nbsp;';
				if ($userPermissions != "view" && $userConnected == "admin") echo '<a href="mainMenu?agent='. base64_encode(base64_encode("all")) .'"><img style="vertical-align:middle" src="images/universalCMD.svg" border="none" class="tooltip" title="Send command to all agents"/></a></p>';
				else echo '<img style="vertical-align:middle" src="images/universalCMD.svg" border="none" class="tooltip" title="Send command to all agents"/></p>';
			?>
		</div><br>

		<?php
			include "inc/open-db-connection.php";
			$_SESSION['id_uniq_command']=null;
			$result_a = mysql_query("SELECT agent,heartbeat, now(), system, version FROM t_agents ORDER BY heartbeat DESC");

			if ($row_a = mysql_fetch_array($result_a))
			{
 				// Code for paint the table two (agents) via AJAX

 				echo '<div id="tableHolder"></div>';
			}
		?>

		<br>
	</div>

	<center>
	<div style="width:1316px; overflow:hidden; border:1px solid #d3d3d3; background:#fefefe; -moz-box-shadow: 0 0 4px rgba(0, 0, 0, 0.2); 
	-webkit-box-shadow: 0 0 4px rgba(0, 0, 0, 0.2); border-spacing: 0px; text-align: left; padding: 10px 10px 10px 10px;">
		
		<?php
			unset($_SESSION['id_command']);
			unset($_SESSION['seconds_waiting']);
			unset($_SESSION['NRF']);
			unset($_SESSION['waiting_command']);
			unset($_SESSION['NRF_CMD']);
			unset($_SESSION['agentchecked']);
 
			$command_console_enabled = "no";

			if (!isset($_GET['agent'])) 
			{
				echo '<strong style="font-family: \'FFont\', sans-serif; font-size:14px; color: #474747;">Please give an instruction to execute</strong><br><br>';
				$command_console_enabled = "no";	
				unset($_SESSION['agentchecked']);
			}
			else if ($userPermissions != "view")
			{
				$command_console_enabled = "yes";
				$agent_dec=base64_decode(base64_decode($_GET['agent']));
				$agent = $agent_dec;
                                $_SESSION['agent']=$agent;
				$_SESSION['agentchecked']=$agent_dec;	
  				echo '<strong style="font-family: \'FFont\', sans-serif; font-size:14px; color: #474747;">Please give an instruction to execute on '.$agent.'</strong><br><br>';
  			}
		?>

  		<div id="result"></div>
  		<?php
			if ($command_console_enabled == "yes" && $userPermissions != "view")
			{
   				echo '<form id="fo3" name="fo3" method="post" action="saveCommands?agent='.$agent.'">';
   				
				echo '<strong style="font-family: Verdana; font-size: 30px; color: #474747;">$ </strong><input class="intext" type="text" autocomplete="off" placeholder=":type instruction here" name="commands" id="commands" 
				style="font-family: Courier new; font-size: 25px; width: 96%; padding: 5px; border: solid 2px #c9c9c9; -webkit-transition: border 0.3s; -moz-transition: border 0.3s; 
				-o-transition: border 0.3s; transition: border 0.3s;" onkeypress="iSubmitEnter(event, document.form1)" >';
   					
				echo '<br><br><div style="font-family: Courier new; font-size: 13px; color: #474747;" id="commandStatus"></div>';
   				echo '</form>';
			}
			else
			{
				echo '<form id="fo3" name="fo3" method="post" action="#">';
                                echo '<strong style="font-family: Verdana; font-size: 30px; color: #474747;">$ </strong><input class="intext" type="text" disabled autocomplete="off" placeholder=":type instruction here" name="commands" id="commands"
                                style="font-family: Courier new; font-size: 25px; font-weight: normal; width: 96%; padding: 5px; border: solid 2px #c9c9c9; -webkit-transition: border 0.3s; -moz-transition: border 0.3s; 
				-o-transition: border 0.3s; transition: border 0.3s;" onkeypress="iSubmitEnter(event, document.form1)" >';
                                echo '<br><br><div style="font-family: Courier new; font-size: 13px; color: #474747;" id="commandStatus"></div>';
                                echo '</form>';
			}
  		?>

	</div>

	<div id="tableHolderXML"></div>

	<div id="includedFooterContent"></div><br>&nbsp;<br>&nbsp;

	<?php
		include "inc/close-db-connection.php";

	?>

	<!-- Modal for deletion -->

	<div class="modal fade" id="confirm-delete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
 		<div class="modal-dialog">
  			<div class="modal-content">
   				<div class="modal-header">
    					<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
    					<h4 class="modal-title" id="myModalLabel" style="text-align:center; font-family:Verdana; font-size: 24px;">Confirm Delete</h4>
   				</div>

   				<div class="modal-body">
    					<p style="text-align:left; font-family:Verdana; font-size: 12px;"><br>You are about to delete the agent, this procedure is irreversible and delete database entries and files without recovery opportunity. Do you want to proceed ?</p>
    					<p class="debug-url" style="text-align:left; font-family:Verdana; font-size: 12px;"></p>
   				</div>

	   			<div class="modal-footer">
   		 			<button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
    					<a href="#" class="btn btn-danger danger">Delete</a>
   				</div>
			</div>
  		</div>
 	</div>
</body>
</html>
