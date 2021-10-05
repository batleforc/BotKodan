# Bot kodan

## Fonctionnalité

- Agenda
- Modification de l'agenda (check toute les [env.checkTime default: 1H] pour des modification)
- Détection periode Entreprise
- Stockage des devoir <MVP
- Calcul des dead line pour chaque devoir ( Attribution a la prochaine occurence du cours)
- Génération de notification par devoir (si demander)
- Trigger un refresh
- Auhtentification de l'ui via les service Discord
- Gestion des droit sur le bot via configuration comme pour les teams concourse

- UI? possible

## Process INIT

- Check BDD, init if needed <MVP
- Check ICS link working
- Check ICS link content
- Update BDD <MVP
- Notif avertissant si une update du bot a été fait et de sa version (ou juste un msg de démarrage) <MVP
- Notif des modification faite dans la bdd et de quand dattait la version de la bdd
- Notif des devoir approchant <MVP
- Mise en place de fonction maison
- Mise en place de commande discord

## Process a interval

- Each day
  - Tout les soir (Avant 19H)
    - EDT du lendemain
    - Devoir pour le lendemain
  - [env.checkTime default: 1H]
    - Update de l'agenda
    - Déplacement des devoir si nécessaire
    - Notif lors d'une modification
- Each Week
  - Le dimanche et le mercredi avant 19H
    - EDT de la semaine
    - Devoir de la semaine et par jours

## Interet et/ou fonctionnalité futur

- Possibilité de dev des adaptateur pour n'importe quelle plateforme. <MVP
- Mise en place d'une logique hexagonale <MVP
- Mise en place d'un systéme de Service en HotReload (Sys Plug-Play maison ?) <MVP
- Multi Language ?
- DOCKERISATION !!! <MVP
- Service avec Tray Icon ? (Win, Linux, Mac si ui)

## Wording

| Word      | description                                            |
| :-------- | :----------------------------------------------------- |
| mvp       | Minimum viable product                                 |
| GraphQL   | Process de communication avec l'api, différent du rest |
| HotReload | Rechargement du service en cas de modification         |

## Userfull link

[FetchDataLink](https://apps.univ-lr.fr/cgi-bin/WebObjects/ServeurPlanning.woa/wa/ics?login=[Username]&debut=01/01/2020%2008:00&fin=31/12/2025%2023:00)
