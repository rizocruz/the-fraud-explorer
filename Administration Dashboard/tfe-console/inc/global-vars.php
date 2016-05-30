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
 * Description: Code for global vars
 */

$serverURL = "https://tfe-console.mydomain.com";
$analyticsURL = "http://tfe-analytics.mydomain.com:81/app/kibana#/discover?_g=(refreshInterval:(display:Off,pause:!f,value:0),time:(from:now%2Fd,mode:quick,to:now%2Fd))&_a=(columns:!(_source),index:'logstash-*',\
		interval:auto,query:(query_string:(analyze_wildcard:!t,query:'*')),sort:!('@timestamp',desc))";
$documentRoot = "/var/www/html/tfe-console/";
