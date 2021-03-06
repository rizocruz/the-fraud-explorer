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
 * Description: Code for erase commands
 */

session_start();

include "inc/global-vars.php";

if(empty($_SESSION['connected']))
{
 	header ("Location: ".$serverURL);
 	exit;
}

error_reporting(0);

function filter($variable)
{
 	return addcslashes(mysql_real_escape_string($variable),',<>');
}

$com = filter($_POST['commands']);
$xml = simplexml_load_file('update.xml');

foreach ($xml->version as $version)
{
 	$numVersion = (int) $version['num'];
}

$numVersion++;
$xmlContent="<?xml version=\"1.0\"?>\r\n<update>\r\n<version num=\"" . $numVersion . "\" />\r\n";
$xmlContent = $xmlContent . "</update>";
$fp = fopen('update.xml',"w+");
fputs($fp, $xmlContent); 
fclose($fp);

/* Clear session variables */

unset($_SESSION['id_command']);
unset($_SESSION['seconds_waiting']);
unset($_SESSION['NRF']);
unset($_SESSION['waiting_command']);
unset($_SESSION['NRF_CMD']);
unset($_SESSION['agentchecked']);

header("Location: ".$serverURL."/mainMenu"); 
?>
