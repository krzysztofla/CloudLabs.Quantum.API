docker pull redis

docker run -p 6379:6379 --name redis -e REDIS_REPLICATION_MODE=master -e ALLOW_EMPTY_PASSWORD=yes redis