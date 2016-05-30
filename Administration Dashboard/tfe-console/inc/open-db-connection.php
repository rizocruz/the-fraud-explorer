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
 * Description: Code for setup DB connection
 */

$dbhost="localhost";
$dbuser="tfe";
$dbpassword="mypass";
$db="thefraudexplorer";
$connection = mysql_connect($dbhost, $dbuser, $dbpassword);
mysql_select_db($db, $connection);

?>
