--clone

 docker run --name repo alpine/git clone https://github.com/docker/getting-started.git

> docker cp repo:/git/getting-started/ .

-- build

> cd getting-started

> docker build -t docker101tutorial .

-- run

> docker run -d -p 80:80 --name docker-tutorial docker101tutorial

-- share

> docker tag docker101tutorial jac21/docker101tutorial

> docker push jac21/docker101tutorial

-- "In the default daemon configuration on Windows, the docker client must be run elevated to connect"

Open cmd as administrator

> C:\Program Files\Docker\Docker\DockerCli.exe" -SwitchDaemon


-- kube

> minikube start

> kubectl get nodes

> kubectl get pods --all-namespaces -o wide

> kubectl apply -f mysql.yaml
> kubectl apply -f mongodb.yaml