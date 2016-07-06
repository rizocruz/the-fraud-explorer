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
 * Date: 2016-07
 * Revision: v0.9.7-beta
 *
 * Description: Code for refresh XML file under mainMenu
*/

session_start();

if(empty($_SESSION['connected']))
{
 	header ("Location: index");
 	exit;
}

include "inc/global-vars.php";
include $documentRoot."inc/cryptography.php";
include $documentRoot."inc/open-db-connection.php";

$xml=simplexml_load_file('update.xml');
$type = $xml->token[0]['type'];
$arg = $xml->token[0]['arg'];
$id = $xml->token[0]['id'];
$agt = $xml->token[0]['agt'];
$version = $xml->version[0]['num'];

?>

<link rel="stylesheet" type="text/css" href="css/xmlConsole.css">

<div class="table">
<div class="tablerow">
	<div class="commandh">
		<center><b>COMMAND</b></center>
	</div>
	<div class="uniqueidh">
                <center><b>ID</b></center>
        </div>
	<div class="agenth">
                <center><b>AGENT</b></center>
        </div>
	<div class="eventh">
                <center><b>NUM</b></center>
        </div>
	<div class="paramh">
                <center><b>PARAMETERS AND ARGUMENTS</b></center>
        </div>
</div>
	
<?php

	if ($type != "")
	{
		echo '<div class="tablerow">';
		echo '<div class="commandd">';
 		echo '<center>'.decRijndaelWOSC($type).'</center>';
		echo '</div>';
		echo '<div class="uniqueidd">';
                echo '<center>'.$id.'</center>';
                echo '</div>';
		echo '<div class="agentd">';
                echo '<center>'.decRijndaelWOSC($agt).'</center>';
                echo '</div>';
		echo '<div class="eventd">';
                echo '<center>'.$version.'</center>';
                echo '</div>';
		echo '<div class="paramd">';
                if ($arg != "") echo '<center>'.decRijndaelWOSC($arg).'</center>';
         	else echo '<center>blank or none at the moment</center>';
	        echo '</div>';
	}
	else
	{
		echo '<div class="tablerow">';
                echo '<div class="commandd">';
                echo '<center>Nothing yet</center>';
                echo '</div>';
                echo '<div class="uniqueidd">';
                echo '<center>No ID</center>';
                echo '</div>';
                echo '<div class="agentd">';
                echo '<center>No agent command</center>';
                echo '</div>';
                echo '<div class="eventd">';
                echo '<center>No number</center>';
                echo '</div>';
                echo '<div class="paramd">';
                echo '<center>blank or none at the moment</center>';
                echo '</div>';
	}

	include $documentRoot."inc/close-db-connection.php";

?>
</div>
