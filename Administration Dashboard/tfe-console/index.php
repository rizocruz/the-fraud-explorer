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
 * Description: Code for login page
 */

 include "inc/check-access.php";

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>The Fraud Explorer</title>
		<meta http-equiv="X-Frame-Options" content="deny">
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<link rel="stylesheet" type="text/css" href="css/index.css" media="screen" />
	</head>
	<body>
	
	<br><br><br>
	<div align="center">
		<table width="500px" height="200px" border="0px">
 			<th bgcolor="#647687" style="font-family: 'FFont', sans-serif; font-size:16px; color:black;">Please enter the following data<br></th>
  			<tbody bgcolor="#eee">
   			<tr>
    				<td align="left" style="font-family: 'FFont', sans-serif; font-size:12px; color:black;">
     					<form id="form1" name="form1" method="post" action="login">
    					<center><br>
     					<table style="border:0px solid white; -moz-box-shadow: 0 0 0px rgba(0, 0, 0, 0.2); -webkit-box-shadow: 0 0 0px rgba(0, 0, 0, 0.2);" bgcolor="#eee">
     						<tr>
      						<td style="border-top:0px solid #e0e0e0; border-right:0px solid #e0e0e0;">
       							Login
      						</td>
      						<td style="border-top:0px solid #e0e0e0; border-right:0px solid #e0e0e0;">
       							<input type="text" name="user" id="user" autocomplete="off" placeholder=":enter your username" style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:220px; height: 15px; 
							padding: 5px; border: solid 2px #c9c9c9;">
      						</td>
      						<td rowspan="3" style="border-top:0px solid #e0e0e0; border-right:0px solid #e0e0e0;">
       							<center><img src="captcha"/></center><br>
       							&nbsp;&nbsp;<input type="submit" name="loginok" value="Sign In Now" style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:100px; height: 18px;">
      						</td>
    					 	</tr>
     						<tr>
      						<td style="border-top:0px solid #e0e0e0; border-right:0px solid #e0e0e0;">
       							Password&nbsp;&nbsp;
      						</td>
      						<td style="border-top:0px solid #e0e0e0; border-right:0px solid #e0e0e0;">
       							<input type="password" name="pass" id="pass" placeholder=":enter your password" style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:220px; height: 15px; 
							padding: 5px; border: solid 2px #c9c9c9;">
      						</td>
     						</tr>
    						<tr>
     						<td style="border-top:0px solid #e0e0e0; border-right:0px solid #e0e0e0;">
      							Captcha&nbsp;&nbsp;
     						</td>
     						<td style="border-top:0px solid #e0e0e0; border-right:0px solid #e0e0e0;">
      							<input type="captcha" name="captcha" id="captcha" placeholder=":enter captcha value" style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:220px; height: 15px; padding: 5px; 
							border: solid 2px #c9c9c9;"> 
     						</td>
    						</tr>
    					</table><br>
    					</center>
    					</form> 
    				</td>
   			</tr>
  			</tbody>
		</table>
	<br>
	</div>
	</body>
</html>
