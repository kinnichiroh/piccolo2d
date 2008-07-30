#!/bin/sh
###########################################################
# Create and deploy the current maven site (snapshot) #####
###########################################################
#
# As it doesn't seem sensible to deploy the maven site to
# GoogleCode via
#  
# <extension>
#	<groupId>org.apache.maven.wagon</groupId>
#	<artifactId>wagon-webdav</artifactId>
#	<version>1.0-beta-2</version>
# </extension>
# 
# as this causes thousands of commits, we'll try another way.
#

base=https://piccolo2d.googlecode.com/svn/site/piccolo2d.java
version=1.3-SNAPSHOT

cwd=`pwd`
tmp=target/site-stage
msg="--message \"$0\""
svn="svn"
#svn="echo svn"

# create a fresh site
#mvn clean install site

# prepare the material to upload
$svn mkdir $msg $base/release-$version 2> /dev/null
rm -rf $tmp
$svn checkout $base/release-$version $tmp

cp -r target/site $tmp/piccolo2d
cp -r core/target/site $tmp/piccolo2d-core
cp -r extras/target/site $tmp/piccolo2d-extras
cp -r examples/target/site $tmp/piccolo2d-examples

# issue the (local) svn commands (delete/add)
cd $tmp
find . -type f | xargs svn status --verbose 2> /dev/null | egrep -e "^\!" | cut --characters=9- | xargs --no-run-if-empty $svn delete
find . -mindepth 1 -type d | xargs --no-run-if-empty svn status --verbose 2> /dev/null | egrep -e "^\?" | cut --characters=9- | xargs --no-run-if-empty $svn add
find . -type f | xargs svn status --verbose 2> /dev/null | egrep -e "^\?" | cut --characters=9- | xargs --no-run-if-empty $svn add --non-recursive

# finish
find . -name "*.html" | xargs $svn propset svn:mime-type text/html
find . -name "*.xml" | xargs $svn propset svn:mime-type text/xml
find . -name "*.css" | xargs $svn propset svn:mime-type text/css
find . -name "*.gif" | xargs $svn propset svn:mime-type image/gif
find . -name "*.png" | xargs $svn propset svn:mime-type image/png
$svn $msg commit .
$svn update
$svn status

# go back where we came from
cd $cwd

