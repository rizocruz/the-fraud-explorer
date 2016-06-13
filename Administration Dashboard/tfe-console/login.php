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
 * Description: Code for login control
 */

include "inc/check-access.php";
include "inc/global-vars.php";

/* HTTPS mandatory

if(!isset($_SERVER['HTTPS']) || !$_SERVER['HTTPS'])
{
   header("HTTP/1.1 301 Moved Permanently");
   header("Location: ".$serverURL);
   exit();
}

*/

session_start();

include "inc/open-db-connection.php";

function filter($variable)
{
 	return addcslashes(mysql_real_escape_string($variable),',<>');
}

$user = filter($_POST["user"]);
$pass = sha1(filter($_POST["pass"]));
$captcha = filter($_POST["captcha"]);

$sql = "SELECT * FROM t_users WHERE user='".($user)."' AND password='".($pass)."'";
$result_a = mysql_query($sql);
$rowUser = mysql_fetch_row($result_a);

$sql2 = "SELECT count(*) FROM t_captcha WHERE captcha='".($captcha)."'";
$result_b = mysql_query($sql2);

if ($row = mysql_fetch_array($result_b))
{
 	if($row[0]>0)
 	{
  		if($rowUser != FALSE)
  		{
    			$_SESSION['connected']=1;
    			$_SESSION['user_con']=$user;
			$_SESSION['user_scope']=$rowUser[2];
			$_SESSION['user_permissions']=$rowUser[3];
    			Header("Location: mainMenu");
  		}
  		else
  		{
   			header ("Location: index");
   			exit;
  		}
 	}
 	else
 	{
  		header ("Location: index");
  		exit;
 	}
}

include "inc/close-db-connection.php";

?>
