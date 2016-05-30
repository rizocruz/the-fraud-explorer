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
 * Description: Code for download and view authorization
 */

include "inc/check-access.php";

session_start();

include "inc/global-vars.php";
$file=$_GET['file'];
$ext = substr($file, strrpos($file, '.')+1);

if( isset($_GET['ctype']) ) { $contentType=$_GET['ctype']; }
else { $contentType="aplication/octet-stream"; }

if(empty($_SESSION['connected']))
{
 	header ("Location: ".$serverURL);
 	exit;
}
else
{
 	if($ext=="txt")
 	{
  		header('Content-Type: text/'.$contentType);
  		flush();
  		readfile($_REQUEST['file']);
  		exit();
 	}
 	else if($ext=="html" || $ext=="htm")
 	{
  		header('Content-Type: text/'.$contentType);
  		flush();
  		readfile($_REQUEST['file']);
  		exit();
 	}
	else if($ext=="png")
 	{
  		header('Content-Type: image/'.$contentType);
  		flush();
  		readfile($_REQUEST['file']);
 	 	exit();
 	}
 	else if($ext=="wav")
 	{
		header('Content-Description: File Transfer');
  		header("Content-Type: audio/x-wav");
		header("Content-Transfer-Encoding: binary"); 
		header("Content-Length: " .filesize($file));
		header('Content-Disposition: attachment; filename="'.$file . '"; ');
    		header('Cache-Control: must-revalidate, post-check=0, pre-check=0');
    		header('Pragma: public');
		header('Expires: 0');
  		flush();
  		readfile($file);
  		exit();
 	}
 	else
 	{
  		if (file_exists($file))
  		{
   			header("Expires: 0");
   			header("Content-Description: File Transfer");
   			header("Content-type: ".$contentType );
   			header("Content-Disposition: attachment; filename=$file");
   			header("Content-Transfer-Encoding: binary");
   			header("Content-Length: ".filesize($file));
   			ob_clean();
   			flush();
   			readfile($file);
   			exit;
  		}
 	}
}

?>
