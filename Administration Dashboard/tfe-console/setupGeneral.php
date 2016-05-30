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
 * Description: Code for general setup
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

if (isset($_GET['key'])) 
{
	$password=filter($_POST['key']);
	mysql_query(sprintf("UPDATE t_crypt SET password='%s'",$password));
}

if (isset($_GET['adduser']))
{
	$username=filter($_POST['username']);
        $password=sha1(filter($_POST['password']));
	$scope=filter($_POST['scope']);
	$permissions=filter($_POST['permissions']);
	mysql_query(sprintf("INSERT INTO t_users (user, password, scope, permissions) VALUES('%s','%s','%s','%s')", $username, $password, $scope, $permissions));
}

if (isset($_GET['deleteuser']))
{
        $username=filter($_POST['user']);
        mysql_query(sprintf("DELETE FROM t_users WHERE user='%s'", $username));
}

if (isset($_GET['changepassword']))
{
        $username=filter($_POST['user']);
        $password=sha1(filter($_POST['password']));
        mysql_query(sprintf("UPDATE t_users SET password='%s' WHERE user='%s'", $password, $username));
}

if (isset($_GET['changerole']))
{
        $username=filter($_POST['user']);
	$scope=filter($_POST['scope']);
        $permissions=filter($_POST['permissions']);
        mysql_query(sprintf("UPDATE t_users SET scope='%s', permissions='%s' WHERE user='%s'", $scope, $permissions, $username));
}


header ("location: generalSetup");

include "inc/close-db-connection.php";
?>
</body>
</html>
