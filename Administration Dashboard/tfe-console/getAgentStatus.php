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
 * Description: Code for refresh agents state under console and shell using AJAX
 */

include "inc/check-access.php";

?>

<?php

function isConnected($update_date, $now)
{ 
 	$date_1 = strtotime($update_date); 
 	$date_2 = strtotime($now);
 	$dife= $date_2 - $date_1;
 	$minutesstr = ($dife/60); 
 	$minutes = (INT)($minutesstr);
 	if ($minutes<0) $minutes = $minutes * -1; 
 	return $minutes<1; 
} 

include "inc/open-db-connection.php";

function filter($variable)
{
 	return addcslashes(mysql_real_escape_string($variable),',<>');
}

$_SESSION['id_uniq_command']=null;
$agent = filter($_GET['agent']);
$agent_dec = base64_decode(base64_decode(filter($_GET['agent'])));

$query="SELECT agent,heartbeat,now() FROM t_agents WHERE agent = \"" .$agent_dec. "\"";
$result_a = mysql_query($query);

if ($row_a = mysql_fetch_array($result_a))
{
  	if(isConnected($row_a["heartbeat"], $row_a[2])) { echo '<img src="images/on.png" border="0">'; }
  	else { echo '<img src="images/off.png" border="0">'; }
}

include "inc/close-db-connection.php";

?>
