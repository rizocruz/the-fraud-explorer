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
 * Description: Code for console interface
 */

include "inc/check-access.php";
session_start();
header("Cache-Control: no-store, no-cache, must-revalidate");
include "inc/global-vars.php";

if(empty($_SESSION['connected']))
{
 	header ("Location: ".$serverURL);
 	exit;
}

function filter($variable)
{
 	return addcslashes(mysql_real_escape_string($variable),',<>');
}

error_reporting(0);
$agent_dec=base64_decode(base64_decode($_GET['agent']));

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
 	<meta http-equiv="X-Frame-Options" content="deny">

 	<!-- JQuery 11 inclusion -->

 	<script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>

 	<!-- Ajax for capture ENTER key in command line -->

 	<script language="JavaScript" type="text/javascript" src="js/ajax.js"></script>

	<!-- JS functions -->

	<script type="text/javascript" src="js/console.js"></script>
	<link rel="stylesheet" type="text/css" href="css/console.css" media="screen" />
</head>
<body>
	<div align="center" width="100%"><br>

			<font face="Verdana" size="2px" color="black">
			<table width="1236px">
			<tbody>
 				<tr>
  					<td width="100%">
  						<strong>Please give a command to execute on <?php echo $agent_dec; ?></strong><br>
  						<?php
   							$agent = filter($_GET['agent']);
   							$_SESSION['agent']=$agent_dec;
  						?>
  						<div id="result"></div>
  						<?php
   							echo '<font face="Courier New" size="10px"><form id="fo3" name="fo3" method="post" action="saveCommands?agent='.$agent_dec.'">';
   							echo '<strong>> </strong><input class="intext" type="text" autocomplete="off" placeholder=":type command here" name="commands" id="commands" style="width: 92%; padding: 5px; border: solid 2px #c9c9c9; -webkit-transition: border 0.3s; -moz-transition: border 0.3s; -o-transition: border 0.3s; transition: border 0.3s;" onkeypress="iSubmitEnter(event, document.form1)" ></font>';
   							echo '<font face="Courier New" size="2px"><br><br><div id="commandStatus"></div>';
   							echo '</form></font>';
  						?>
  					</td>
 				</tr>
			</tbody>
			</table>
			</font>
		</div>
	</div>
</body>
</html>
