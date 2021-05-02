FROM microsoft/mssql-server-linux:2017-latest

COPY ./dockerfiles/db /db

# Grant permissions for script to be executable
RUN chmod +x /db/*

ENTRYPOINT [ "/bin/bash", "/db/docker-entrypoint.sh" ]
CMD [ "/opt/mssql/bin/sqlservr" ]