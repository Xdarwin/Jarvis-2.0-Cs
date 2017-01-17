ATTENTION:
C'est un ancien projet, réalisé par des débutants sans aucune rigueur ou structure.
Le code n'est pas propre, n'a aucune coding-style et pourrait grandement être amélioré.

Projet de débutants en programmation fait durant ma terminale.
Utilisation d'un cafetière modifiée par nos soins (en soudant directement sur la carte électronique de la cafetière)
puis en l'utilisant via notre ordinateur grâce à du sans-fil.
L'ordinateur utilise un logiciel de reconnaissance vocale de base,
via la bibliothèque Speech de .NET, pour envoyer des ordres à la cafetière.

Le PC possède le logiciel contenu dans ce repository avec quelques changements (on a modifié quelques lignes depuis).
On parle au logiciel qui comprend, via une grammaire contenant des phrases fixes, que l'on veut un ou deux cafés.
L'ordinateur doit être relié à une Arduino, elle-même reliée avec un emetteur IR.
Le premier envoie un message qui est traduit par l'Arduino qui emet à l'autre Arduino, dans la cuisine à côté de la cafetière.
La cafetière est reliée à une Arduino possèdant un récepteur IR et un relais.
Un relais pour simuler l'appuie de tel ou tel bouton.
