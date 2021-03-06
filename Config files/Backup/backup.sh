#!/bin/bash

# Purpose = Backup of Important Data

TIME=`date +"%b-%d-%y"`
FILENAME="backup-data-${TIME}.tar.gz"
TFEDIR="/var/www/html/tfe-console /var/www/html/tfe-input"
ANALYTICSDIR="/etc/elasticsearch /opt/kibana /etc/nginx /etc/logstash"
SYSFILES="/etc/sysconfig /etc/my.cnf /etc/httpd /etc/php.ini /etc/inittab /backup/bin/backup.sh /etc/motd /etc/postfix /etc/hosts "
DESDIR="/backup"

tar -cpzf ${DESDIR}/$FILENAME $TFEDIR $ANALYTICSDIR
tar -cpzf ${DESDIR}/backup-operating-system-configs-${TIME}.tar.gz $SYSFILES
mysqldump -u root thefraudexplorer > /backup/thefraudexplorer-${TIME}.sql
tar -cpzf /backup/all-backup-${TIME}.tar.gz /backup/${FILENAME} /backup/backup-operating-system-configs-${TIME}.tar.gz /backup/thefraudexplorer-${TIME}.sql
zip --password SUCLAVE /backup/backup-${TIME}.zip /backup/all-backup-${TIME}.tar.gz
rm -f /backup/all-backup-${TIME}.tar.gz /backup/backup-data-${TIME}.tar.gz /backup/backup-operating-system-configs-${TIME}.tar.gz /backup/thefraudexplorer-${TIME}.sql
