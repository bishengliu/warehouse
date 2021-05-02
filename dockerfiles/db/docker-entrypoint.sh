#!/bin/bash
set -e

if [ "$1" = '/opt/mssql/bin/sqlservr' ]; then
    function initialize_app_database() {
      # Wait a bit for SQL Server to start. SQL Server's process doesn't provide a clever way to check if it's up or not, and it needs to be up before we can import the application database
      if [ ! -f /tmp/app-initialized ]; then
          sleep 15s
          touch /tmp/app-initialized
      fi

      sleep 30s;
      export PATH="$PATH:/opt/mssql-tools/bin"

      # Always run SQL files, be sure to add validations so it wont execute multiple times.
      for file in /db/*.sql; do
        [ -e "$file" ] || continue

        echo "Executing SQL file $file"
        sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -i "$file"
      done

      # Note that the container has been initialized so future starts won't wipe changes to the data
    }
    initialize_app_database &
fi

exec "$@"