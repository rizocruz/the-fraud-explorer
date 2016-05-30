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
 * Description: Code for refresh XML file under mainMenu, through AJAX
*/

include "inc/check-access.php";
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

<style type="text/css">

* { 
    -moz-box-sizing: border-box;
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
}

.table 	   
{ 
 display: table; 
 border-collapse: collapse; 
 width: 1316px; 
 background:transparent;
 -moz-box-shadow: 0 0 4px rgba(0, 0, 0, 0.2);
 -webkit-box-shadow: 0 0 4px rgba(0, 0, 0, 0.2);
 border-spacing: 0px;
}

.tablerow  
{ 
 border:1px solid #d3d3d3; 
 display: table-row; 
 background:#fefefe;
}

.commandh  { font-size: 10px; background:#e8eaeb; height: 35px; width: 150px; display: table-cell; vertical-align: middle; font-family: 'FFont', sans-serif; font-size:12px; color: #474747; }
.uniqueidh { font-size: 10px; background:#e8eaeb; height: 35px; width: 100px; display: table-cell; vertical-align: middle; font-family: 'FFont', sans-serif; font-size:12px; color: #474747; }
.agenth    { font-size: 10px; background:#e8eaeb; height: 35px; width: 230px; display: table-cell; vertical-align: middle; font-family: 'FFont', sans-serif; font-size:12px; color: #474747; }
.eventh    { font-size: 10px; background:#e8eaeb; height: 35px; width: 100px; display: table-cell; vertical-align: middle; font-family: 'FFont', sans-serif; font-size:12px; color: #474747; }
.paramh    { font-size: 10px; background:#e8eaeb; height: 35px; width: 656px; display: table-cell; vertical-align: middle; font-family: 'FFont', sans-serif; font-size:12px; color: #474747; }

.commandd  
{ 
 background: white;
 height: 50px; width: 150px; display: table-cell; vertical-align: middle; 
 border-right:1px solid #F8F8F8;
 border-top:1px solid #d3d3d3;
 border-bottom:1px solid #d3d3d3;
 font-family: 'FFont', sans-serif; font-size:12px; color: #474747;
}

.uniqueidd 
{
 background: white; 
 height: 50px; width: 100px; display: table-cell; vertical-align: middle; 
 border-right:1px solid #F8F8F8;
 border-top:1px solid #d3d3d3;
 border-bottom:1px solid #d3d3d3;
 font-family: 'FFont', sans-serif; font-size:12px; color: #474747;
} 

.agentd    
{
 background: white; 
 height: 50px; width: 230px; display: table-cell; vertical-align: middle; 
 border-right:1px solid #F8F8F8;
 border-top:1px solid #d3d3d3;
 border-bottom:1px solid #d3d3d3;
 font-family: 'FFont', sans-serif; font-size:12px; color: #474747;
} 

.eventd    
{
 background: white; 
 height: 50px; width: 100px; display: table-cell; vertical-align: middle; 
 border-right:1px solid #F8F8F8;
 border-top:1px solid #d3d3d3;
 border-bottom:1px solid #d3d3d3;
 font-family: 'FFont', sans-serif; font-size:12px; color: #474747;
}

.paramd    
{
 background: white;
 height: 50px; width: 656px; display: table-cell; vertical-align: middle; 
 border-top:1px solid #d3d3d3;
 border-bottom:1px solid #d3d3d3;
 font-family: 'FFont', sans-serif; font-size:12px; color: #474747;
}

</style>

<br>
<div class="table">
<div class="tablerow">
	<div class="commandh">
		<center><b>COMMAND SENT</b></center>
	</div>
	<div class="uniqueidh">
                <center><b>UNIQUE ID</b></center>
        </div>
	<div class="agenth">
                <center><b>AGENT</b></center>
        </div>
	<div class="eventh">
                <center><b>EVENT NUM</b></center>
        </div>
	<div class="paramh">
                <center><b>PARAMETERS AND ARGUMENTS TO THE COMMAND QUEUE</b></center>
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
