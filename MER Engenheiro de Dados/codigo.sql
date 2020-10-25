/* Lógico_1: */

CREATE TABLE cliente (
    clientID INTEGER PRIMARY KEY
);

CREATE TABLE cliente_visit (
    fullVisitorId INTEGER,
    visitorId INTEGER,
    userId INTEGER,
    clientID INTEGER,
    totalsID INTEGER,
    trafficSourceID INTEGER,
    visitID INTEGER,
    deviceID INTEGER,
    PRIMARY KEY (fullVisitorId, visitorId)
);

CREATE TABLE visit (
    visitId INTEGER PRIMARY KEY UNIQUE,
    visitStartTime TIME,
    date DATE
);

CREATE TABLE totals (
    totalsID INTEGER PRIMARY KEY,
    totals.bounces INTEGER,
    totals.hits INTEGER,
    totals.newVisits INTEGER,
    totals.pageviews INTEGER,
    totals.sessionQualityDim INTEGER,
    totals.timeOnScreen INTEGER,
    totals.timeOnSite INTEGER,
    totals.totalTransactionRevenue INTEGER,
    totals.transactions INTEGER,
    totals.UniqueScreenViews INTEGER,
    totals.visits INTEGER,
    hitsID INTEGER
);

CREATE TABLE trafficSource (
    trafficSourceID INTEGER PRIMARY KEY,
    trafficSource.adContent INTEGER,
    trafficSource.campaign VARCHAR,
    trafficSource.campaignCode VARCHAR,
    trafficSource.isTrueDirect BOOLEAN,
    trafficSource.keyword VARCHAR,
    trafficSource.medium CHAR,
    trafficSource.referralPath VARCHAR,
    trafficSource.source VARCHAR,
    socialEngagementType VARCHAR,
    channelGrouping CHAR
);

CREATE TABLE trafficSource. adwordsClickInfo (
    trafficSource. adwordsClickInfo.adGroupId  INTEGER PRIMARY KEY,
    trafficSource. adwordsClickInfo.adNetworkType  CHAR,
    trafficSource. adwordsClickInfo.criteriaParameters  VARCHAR,
    trafficSource. adwordsClickInfo.isVideoAd  BOOLEAN,
    trafficSource. adwordsClickInfo.page  INTEGER,
    trafficSource. adwordsClickInfo.slot  CHAR,
    trafficSource. adwordsClickInfo.campaignId  INTEGER,
    trafficSource. adwordsClickInfo.creativeId  INTEGER,
    trafficSource. adwordsClickInfo.criteriaId  INTEGER,
    trafficSource. adwordsClickInfo.customerId  INTEGER,
    trafficSource. adwordsClickInfo.gclId  INTEGER,
    trafficSourceID INTEGER
);

CREATE TABLE trafficSource. adwordsClickInfo.targetingCriteria  (
    trafficSource. adwordsClickInfo.targetingCriteria.boomUserlistId  INTEGER,
    adwordsClickInfo.criteriaId INTEGER PRIMARY KEY
);

CREATE TABLE device (
    deviceID INTEGER PRIMARY KEY,
    device.browser VARCHAR,
    device.browserSize VARCHAR,
    device.browserVersion VARCHAR,
    device.deviceCategory VARCHAR,
    device.mobileDeviceInfo VARCHAR,
    device.mobileDeviceMarketingName VARCHAR,
    device.mobileDeviceModel VARCHAR,
    device.mobileInputSelector VARCHAR,
    device.operatingSystem VARCHAR,
    device.operatingSystemVersion VARCHAR,
    device.flashVersion VARCHAR,
    device.javaEnabled BOOLEAN,
    device.language VARCHAR,
    device.screenColors VARCHAR,
    device.screenResolution VARCHAR,
    customDimensionsID INTEGER,
    geoNetworkID INTEGER
);

CREATE TABLE customDimensions (
    customDimensionsID INTEGER PRIMARY KEY,
    customDimensions.index INTEGER,
    customDimensions.value VARCHAR
);

CREATE TABLE geoNetwork (
    geoNetworkID INTEGER PRIMARY KEY,
    geoNetwork.continent VARCHAR,
    geoNetwork.subContinent VARCHAR,
    geoNetwork.country VARCHAR,
    geoNetwork.region VARCHAR,
    geoNetwork.metro NUMERIC,
    geoNetwork.city VARCHAR,
    geoNetwork.cityId INTEGER,
    geoNetwork.latitude FLOAT,
    geoNetwork.longitude FLOAT
);

CREATE TABLE hits (
    hitsID INTEGER PRIMARY KEY,
    hits.dataSource VARCHAR,
    hits.sourcePropertyInfo VARCHAR
);
 
ALTER TABLE cliente ADD CONSTRAINT FK_cliente_2
    FOREIGN KEY (userId)
    REFERENCES cliente (clientID);
 
ALTER TABLE cliente_visit ADD CONSTRAINT FK_cliente_visit_2
    FOREIGN KEY (clientID???, totalsID???, trafficSourceID???, visitID???, deviceID???)
    REFERENCES ??? (???);
 
ALTER TABLE totals ADD CONSTRAINT FK_totals_2
    FOREIGN KEY (hitsID???)
    REFERENCES ??? (???);
 
ALTER TABLE trafficSource. adwordsClickInfo ADD CONSTRAINT FK_trafficSource. adwordsClickInfo_2
    FOREIGN KEY (trafficSource. adwordsClickInfo.criteriaId ???)
    REFERENCES ??? (???);
 
ALTER TABLE device ADD CONSTRAINT FK_device_2
    FOREIGN KEY (customDimensionsID???, Campo???, geoNetworkID???)
    REFERENCES ??? (???);
 
ALTER TABLE geoNetwork ADD CONSTRAINT FK_geoNetwork_2
    FOREIGN KEY (geoNetwork.cityId???, Campo???)
    REFERENCES ??? (???);