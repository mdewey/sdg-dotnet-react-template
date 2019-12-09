docker build -t sdg-sample-site-template .

docker tag sdg-sample-site-template registry.heroku.com/sdg-sample-site-template/web

docker push registry.heroku.com/sdg-sample-site-template/web

heroku container:release web -a sdg-sample-site-template