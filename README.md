# tennisApiTest

Cette API REST permet de gérer et de récupérer les statistiques des joueurs de tennis.

## Endpoints

- **GET /api/players** : Retourne une liste de joueurs triée par rang.
- **GET /api/players/{id}** : Retourne les détails d'un joueur par ID.
- **GET /api/players/stats** : Retourne des statistiques, y compris :
  - Le pays avec le meilleur ratio de victoires
  - L'IMC moyen de tous les joueurs
  - La médiane de la taille des joueurs

## Exécution locale

### Prérequis

- .NET 8 SDK
- Un éditeur de code ou IDE compatible avec .NET (par exemple, Visual Studio, Visual Studio Code)

### Étapes pour exécuter l'application

1. **Cloner le dépôt :**
    1. git clone https://github.com/aissaoabd/tennisApiTest.git
    2. cd tennisApiTest
    3. dotnet restore // Restaurer les packages NuGet
    4. dotnet build //  Construire la solution
   
3. **Executer l'api :**
    1. cd tennisApiTest
    2. dotnet run // exécuter l'app
  
      
2. **Executer les tests :**
   
   1. cd tennisApiTest.Tests
   2. dotnet test



