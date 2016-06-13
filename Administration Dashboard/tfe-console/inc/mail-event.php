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
 * Description: Mail events
 */

// Code for mail events

  $to      = 'smtp@mydomain.com';
  $subject = 'TFE Event: AGT connected: '. $macAgent;
  
  $message = '<html><body><table border="1" style="background-color:#FFFFFF;border-collapse:collapse;border:1px solid #33CC00;color:#000000;width:100%" ' .
             'cellpadding="8" cellspacing="3"> ' .
             '<tr>' .
             '<td style="background-color:#f6f6f6; border:1px solid #33CC00;"><b>Name</b></td>' .
             '<td style="background-color:#f6f6f6; border:1px solid #33CC00;"><b>Connection date</b></td>' .
             '<td style="background-color:#f6f6f6; border:1px solid #33CC00;"><b>Operating system</b></td>' .
             '<td style="background-color:#f6f6f6; border:1px solid #33CC00;"><b>Version</b></td>' .
             '</tr>' .
             '<tr>' .
             '<td style="background-color:#FFFFFF; border:1px solid #33CC00;">' . $macAgent . '</td>' .
             '<td style="background-color:#FFFFFF; border:1px solid #33CC00;">' . $date .'</td>' .
             '<td style="background-color:#FFFFFF; border:1px solid #33CC00;">' . $os . '</td>' .
             '<td style="background-color:#FFFFFF; border:1px solid #33CC00;">' . $version . '</td>' .
             '</tr>' .
             '</table></body></html>';

  $headers = 'From: smtp@mydomain.com' . "\r\n" .
             'Reply-To: smtp@mydomain.com' . "\r\n" .
             'MIME-Version: 1.0' . "\r\n" .
             'Content-Type: text/html; charset=ISO-8859-1' . "\r\n" .
             'X-Mailer: PHP/' . phpversion();

?>
