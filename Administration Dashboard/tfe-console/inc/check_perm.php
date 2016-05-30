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
 * Description: Code for retrieve user permissions
 */

$userConnected=$_SESSION['user_con'];
$userScope=$_SESSION['user_scope'];
$userPermissions=$_SESSION['user_permissions'];

function whatUser()
{
	return $userConnected;
}

function whatUserScope()
{
 	return $userScope; 
}

function whatUserPermissions()
{
	return $userPermissions;
}

?>
