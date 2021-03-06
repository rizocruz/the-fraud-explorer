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
 * Description: Code for agent deletion
 */

session_start();

include "inc/global-vars.php";

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

$agent_enc=filter($_GET['agent']);
$agent_dec=base64_decode(base64_decode($agent_enc));
error_reporting(0);
$maq=str_replace(array("."),array("_"),$agent_dec);

echo $maq;

/* Delete agent tables */
 
mysql_query(sprintf("DROP TABLE t_%s",$maq));
mysql_query(sprintf("DELETE FROM t_agents WHERE agent='%s'",$maq));

/* Delete agent elasticsearch documents */

$ch = curl_init(); 
curl_setopt($ch, CURLOPT_URL, "http://localhost:9200/_all/_query?q=agentId:".$maq); 
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1); 
curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "DELETE");
curl_exec($ch); 
curl_close($ch);   

/* Return to home */

header ("location:  mainMenu");

include "inc/close-db-connection.php";

?>

</body>
</html>
