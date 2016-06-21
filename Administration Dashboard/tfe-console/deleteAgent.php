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
 * Date: 2016-06-30 15:12:41 -0500 (Wed, 30 Jun 2016)
 * Revision: v0.9.6-beta
 *
 * Description: Code for agent deletion
 */

include "inc/check-access.php";
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

/* Delete agent tables */
 
mysql_query(sprintf("DROP TABLE t_%s",$maq));
mysql_query(sprintf("DELETE FROM t_agents WHERE agent='%s'",$maq));

header ("location:  mainMenu");

include "inc/close-db-connection.php";

?>

</body>
</html>
