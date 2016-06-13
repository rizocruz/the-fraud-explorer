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
 * Description: Code for general setup
 */

include "inc/check-access.php";

session_start();

include "inc/global-vars.php";
include "inc/check_perm.php";

if ($userConnected != "admin") header ("Location: mainMenu");

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

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Setup agent</title>
	<meta http-equiv="X-Frame-Options" content="deny">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

	<!-- JQuery 11 inclusion -->

 	<script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>

 	<!-- Code for Tooltipster -->

 	<link rel="stylesheet" type="text/css" href="css/tooltipster.css"/>
 	<script type="text/javascript" src="js/jquery.tooltipster.js"></script>
 	<link rel="stylesheet" type="text/css" href="css/bootstrap.css">
 	<script src="js/bootstrap.js"></script>

 	<!-- JS functions -->

 	<script type="text/javascript" src="js/generalSetup.js"></script>

 	<link rel="stylesheet" type="text/css" href="css/generalSetup.css" media="screen" />
</head>

<body>
	<div align="center" width="100%">
	
		<div style="width:100%; height:68px; border:1px solid gray; border-top-style: none; border-right-style:none; border-bottom-style: none; 
		 border-left-style: none; background-color: #e8eaeb;"><br>
			<center>
			<div style="width:1316px; background-color: #e8eaeb;">
				<p style="text-align: left; width: 100%; font-family: 'FFont', sans-serif; font-size:26px; color:black;">
				<img style="vertical-align:middle" src="images/nftop.png" width=50 height=50><span style="vertical-align: middle;">&nbsp;<b>TFE</b>&nbsp;&reg; The Fraud Explorer</span></p>
			</div>
			</center>
		</div>
		<br>

		<div style="width:1316px; opacity: 0.9;"><p align=right style="font-family: 'FFont', sans-serif; font-size:22px; color:black;">General system setup&nbsp;

			<a href="mainMenu"><img style="vertical-align:middle" src="images/mainMenu.svg" border="none" class="tooltip" title="Dashboard"/></a>

			<?php
				$link_url="eraseCommands.php";
				echo '<a href="#" class="reset-xml-button" id="'.$link_url.'"><img style="vertical-align:middle" src="images/clearXML.svg" class="tooltip" title="Reset command queue"></a>';
			?>

			<a href="logout"><img style="vertical-align:middle" src="images/logout.svg" border="none" class="tooltip" title="Secure logout"/></a>

			<?php
 				echo '<a href="generalSetup"><img style="vertical-align:middle" src="images/refreshPage.svg" border="none" class="tooltip" title="Refresh page"/></a></td></tr></table><br>';
			?>
 			</p>
		</div>
		<br>

		<table summary="Setup">
		<thead>
			<tr>
				<th class="basicth"><b>SYSTEM CONFIGURATION</b></th>
				<th class="advancedth"><b>USER ADMINISTRATION</b></th>		
			</tr>
		</thead>
		<tbody>
			<tr>
				<td class="basictd">
					<table style="border:1px solid #d3d3d3; width:620px; -moz-box-shadow: 0 0 0px rgba(0, 0, 0, 0.0); -webkit-box-shadow: 0 0 0px rgba(0, 0, 0, 0.0);">
                                                <tbody style="height:110px; width:620px;">
                                                <tr>
                                                        <td>
								Specify/change the key/password for agents connection<br><br>
     								<form id="form1" name="form1" method="post" action="<?php echo 'setupGeneral?key=yes' ?>">
     			  						<input style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:500px; height: 30px;" type="text" name="key" id="key" autocomplete="off" placeholder=":key/password here <?php 
									$keyquery = mysql_query("SELECT password FROM t_crypt"); $keypass = mysql_fetch_array($keyquery); 
									echo '(current value:'.$keypass[0].')'; ?>"

									padding: 5px; border: solid 2px #c9c9c9; -webkit-transition: border 0.3s; -moz-transition: border 0.3s; -o-transition: border 0.3s; 
									transition: border 0.3s;">
       							
									&nbsp;&nbsp;<input style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:85px; height: 30px" type="submit" name="keyok" value="Save key">
    								</form> 
							</td>
						</tr>
						</tbody>
					</table><br><br>

					System users, scopes and permissions<br><br>

					<table style="border:1px solid #d3d3d3; width:620px; -moz-box-shadow: 0 0 0px rgba(0, 0, 0, 0.0); -webkit-box-shadow: 0 0 0px rgba(0, 0, 0, 0.0);">
                                                <tbody style="height:187px; width:620px;">
							<th style="width:400px"><b>USER NAME (LOGIN)</b></th><th style="width:120px"><b>SCOPE</b></th><th style="width:120px"><b>PERMISSIONS</b></th>

							<?php
								$result = mysql_query("SELECT user,scope,permissions FROM t_users WHERE user != 'admin'");
								while($row = mysql_fetch_row($result))
								{
    									echo "<tr>";
    									foreach($row as $cell) echo "<td>$cell</td>";
    									echo "</tr>\n";
								}
							?>
						</tbody>
                                        </table><br><br>

					<table style="border:1px solid #d3d3d3; width:620px; -moz-box-shadow: 0 0 0px rgba(0, 0, 0, 0.0); -webkit-box-shadow: 0 0 0px rgba(0, 0, 0, 0.0);">
                                                <tbody style="height:165px; width:620px;">
                                                <tr>
                                                        <td style="width:440px; height: 165px; text-align: justify;">
                                                                Download and scan QR-CODE to login<br><br>
								You need to download an application in your cell-phone in order to scan this QR code and select the appropiate number at the moment to login. A good application is Duo Mobile that you can
								get from the Apple store. This process is called One Time Password generation (OTP).
                                                        </td>
                                                        <td style="width:183px; text-align: center; vertical-align: middle;">
                                                                <img src="authAccess?file=otpqr/otpqrcode.png" style="width:120px; height: 120px;">
                                                        </td>
                                                </tr>
                                                </tbody>
                                        </table>
				</td>

				<td class="basictd">
					<table style="border:1px solid #d3d3d3; width:620px; -moz-box-shadow: 0 0 0px rgba(0, 0, 0, 0.0); -webkit-box-shadow: 0 0 0px rgba(0, 0, 0, 0.0);">
						<tbody style="height:184px; width:620px;">
						<tr>
							<td>
								New username and password<br><br>
								<form id="form2" name="form2" method="post" action="<?php echo 'setupGeneral?adduser=yes' ?>">

                                		               	<input style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:220px; height: 30px;" type="text" name="username" id="username" autocomplete="off" 
								placeholder=":new username here" padding: 5px; border: solid 2px #c9c9c9; -webkit-transition: border 0.3s; -moz-transition: border 0.3s; -o-transition: border 0.3s;
                                                		transition: border 0.3s;">&nbsp;&nbsp;

								<input style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:220px; height: 30px;" type="password" name="password" id="password" autocomplete="off"
                		                                placeholder=":password here" padding: 5px; border: solid 2px #c9c9c9; -webkit-transition: border 0.3s; -moz-transition: border 0.3s; -o-transition: border 0.3s;
                                		                transition: border 0.3s;"><br>

								<br>Select scope & permissions<br><br>

								<select name="scope" style="font-family: 'FFont', sans-serif; font-size:35px; color:black; width:220px;">
									<?php 
										$sql = mysql_query("SELECT DISTINCT(owner) AS owner FROM t_agents");
										while ($row = mysql_fetch_array($sql))
										{
											echo "<option value=\"".$row['owner']."\">" . $row['owner'] . "</option>";
										}
									?>
								</select>&nbsp;&nbsp;	
		
								<select name="permissions" style="font-family: 'FFont', sans-serif; font-size:35px; color:black; width:220px;">
                                		                	<option value="view">Viewer only</option>
									<option value="subadmin">Company administrator</option>
		                                                </select>
							</td>
							<td style="width:145px;">
								<br><br>
                                		                <input style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:120px; height: 105px" type="submit" name="adduserok" value="Add user">
					     		      	</form>
							</td>
						</tr>
						</tbody>
					</table>

					<br><br><table style="border:1px solid #d3d3d3; width:620px; -moz-box-shadow: 0 0 0px rgba(0, 0, 0, 0.0); -webkit-box-shadow: 0 0 0px rgba(0, 0, 0, 0.0);">
					<tbody style="height:144px; width:620px;">
                                                <tr>
                                                        <td>
								User deletion<br><br>
								<form id="form3" name="form3" method="post" action="<?php echo 'setupGeneral?deleteuser=yes' ?>">
								<select name="user" style="font-family: 'FFont', sans-serif; font-size:35px; color:black; width:180px;">
                                        			<?php
                              	        		          	$sql = mysql_query("SELECT user FROM t_users WHERE user != 'admin'");
                                	                	        while ($row = mysql_fetch_array($sql))
                      		                                	{
             	        	                                   		echo "<option value=\"".$row['user']."\">" . $row['user'] . "</option>";
                	                                       	 	}
                                	                	?>
                                	        		</select><br><br>
								<input style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:180px; height: 26px" type="submit" name="deleteok" value="Delete user">
                                        			</form>
							</td>
							<td>
								Password modification<br><br>
								<form id="form4" name="form4" method="post" action="<?php echo 'setupGeneral?changepassword=yes' ?>">
									
									<select name="user" style="font-family: 'FFont', sans-serif; font-size:35px; color:black; width:180px;">
                                                                	<?php
                                                                        	$sql = mysql_query("SELECT user FROM t_users");
                                                                      	  	while ($row = mysql_fetch_array($sql))
                                                                        	{
                                                                                	echo "<option value=\"".$row['user']."\">" . $row['user'] . "</option>";
                                                                        	}
                                                                	?>
                                                                	</select>&nbsp;&nbsp;

                                                			<input style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:200px; height: 20px;" type="password" name="password" id="password" autocomplete="off" 
									placeholder=":new password here" padding: 5px; border: solid 2px #c9c9c9; -webkit-transition: border 0.3s; -moz-transition: border 0.3s; -o-transition: border 0.3s;
                                                			transition: border 0.3s;">

                                                			<br><br><input style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:390px; height: 26px" type="submit" name="passwordok" value="Change password">
                                        			</form>

							</td>
						</tr>
					</tbody>
					</table>

					<br><br><table style="border:1px solid #d3d3d3; width:620px; -moz-box-shadow: 0 0 0px rgba(0, 0, 0, 0.0); -webkit-box-shadow: 0 0 0px rgba(0, 0, 0, 0.0);">
                                        <tbody style="height:169px; width:620px;">
                                                <tr>
                                                        <td>
                                                                Change user role & permissions<br><br>
                                                                <form id="form5" name="form5" method="post" action="<?php echo 'setupGeneral?changerole=yes' ?>">
                                                                <select name="user" style="font-family: 'FFont', sans-serif; font-size:35px; color:black; width:191px;">
                                                                <?php
                                                                        $sql = mysql_query("SELECT user FROM t_users WHERE user != 'admin'");
                                                                        while ($row = mysql_fetch_array($sql))
                                                                        {
                                                                                echo "<option value=\"".$row['user']."\">" . $row['user'] . "</option>";
                                                                        }
                                                                ?>
                                                                </select>&nbsp;&nbsp;
                                                
								<select name="scope" style="font-family: 'FFont', sans-serif; font-size:35px; color:black; width:191px;">
                                                                        <?php
                                                                                $sql = mysql_query("SELECT DISTINCT(owner) AS owner FROM t_agents");
                                                                                while ($row = mysql_fetch_array($sql))
                                                                                {
                                                                                        echo "<option value=\"".$row['owner']."\">" . $row['owner'] . "</option>";
                                                                                }
                                                                        ?>
                                                                </select>&nbsp;&nbsp;

                                                                <select name="permissions" style="font-family: 'FFont', sans-serif; font-size:35px; color:black; width:191px;">
                                                                        <option value="view">Viewer only</option>
                                                                        <option value="subadmin">Company administrator</option>
                                                                </select>

								<br><br><input style="font-family: 'FFont', sans-serif; font-size:12px; color:black; width:593px; height: 52px;" type="submit" name="changeroleok" value="Change role and/or permissions">
                                                                </form>
                                                        </td>
                                                </tr>
                                        </tbody>
                                        </table>



                                </td>	

			</tr>		
		</tbody>		
		</table>

	</div>		

	<div align="center" id="tableHolderXML"></div>

	<div id="includedFooterContent"></div><br>&nbsp;<br>&nbsp;

	<?php
		include "inc/close-db-connection.php";
	?>

</body>
</html>
