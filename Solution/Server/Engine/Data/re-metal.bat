@ECHO OFF
:: Rebuild the Data Context
:: The source database file needs to be in the build output directory

SET PATH=%PATH%;C:\Program Files\Microsoft SDKs\Windows\v7.0A\bin

sqlmetal ../../../../Build/data.sdf /dbml:EMMDataContext.dbml /pluralize /context:EMMDataContext
pause