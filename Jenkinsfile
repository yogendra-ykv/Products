pipeline {
  agent {
    dockerfile {
      filename 'jenkins-ci'
    }

  }
  stages {
    stage('Build') {
      steps {
        sh 'dotnet build --configuration Release'
      }
    }

    stage('Run Unit Tests') {
      steps {
        sh 'dotnet test --configuration Release --logger trx --results-directory TestResults'
      }
    }

    stage('Publish') {
      steps {
        sh 'dotnet publish -c Release -o publish'
      }
    }

  }
  environment {
    APP_NAME = 'products'
  }
}