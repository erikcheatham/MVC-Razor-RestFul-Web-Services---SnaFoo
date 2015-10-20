Using the database scripts
==========================

1. Create your database. This could be a LocalDB or Azure database, if you have a subscription.
2. Open and run the SnaFoo-db-SQLServer.sql script in your new database
3. (Optional) Open and run the ELMAH-1.2-db.SQLServer.sql script if you are adding ELMAH to your solution and want to store exception data in the database. You will also need to update your ELMAH configuration accordingly.
4. (Optional) Open and run the Log4Net-db-SQLServer.sql script if you are using Log4Net and wish to store log information in the database. You will also need to update your logging configuration to use SQL server.

NOTE: The ELMAH and Log4Net scripts are only included for your convenience if you plan to use
these packages so that you don't have to track them down. They are not needed by the solution
and are not required. As noted there are additional configuration steps for these packages
that are not detail here.