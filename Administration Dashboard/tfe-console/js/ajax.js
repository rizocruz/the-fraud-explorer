/*
 * The Fraud Explorer
 * http://www.thefraudexplorer.com/
 *
 * Copyright (c) 2016 The Fraud Explorer
 * email: customer@thefraudexplorer.com
 * Licensed under GNU GPLv3
 * http://www.thefraudexplorer.com/License
 *
 * Date: 2016-06-30 15:12:41 -0500 (Wed, 30 Jun 2016)
 * Revision: v0.9.6-beta
 *
 * Description: Code for AJAX command console
 */

function ajaxObject()
{
 	var xmlhttp=false;
 	try 
 	{
  		xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
 	} 
 	catch (e) 
 	{
  		try 
  		{
   			xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
  		} 
  		catch (E) 
  		{
   			xmlhttp = false;
  		}
 	}

 	if (!xmlhttp && typeof XMLHttpRequest!='undefined') 
 	{
  		xmlhttp = new XMLHttpRequest();
 	}
 	return xmlhttp;
}

function showQuery(data)
{
 	divResults = document.getElementById('result');
 	ajax=ajaxObject();
 	ajax.open("GET", data);
 	ajax.onreadystatechange=function() 
 	{
  		if (ajax.readyState==4) 
  		{
   			divResults.innerHTML = divResults.innerHTML + ajax.responseText;
  		}
 	}
 	ajax.send(null)
}
