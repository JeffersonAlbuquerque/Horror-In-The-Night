/*Esse c�digo est� usando a fun��o Physics.Raycast para verificar se h� uma colis�o (ou interse��o) 
 * entre um raio e um objeto no cen�rio do jogo. Vamos analisar o c�digo linha por linha:

csharp
Copiar c�digo
RaycastHit hitInfo;
RaycastHit � uma estrutura em Unity usada para armazenar informa��es sobre um ponto de colis�o 
quando um raio (ou um "ray") atinge um objeto no jogo.
hitInfo � uma vari�vel do tipo RaycastHit que ser� preenchida com informa��es sobre o 
ponto de colis�o se houver uma.
csharp
Copiar c�digo
if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, distance))
{
    // C�digo a ser executado se o raio atingir um objeto
}
if (Physics.Raycast(...)) � uma estrutura condicional que verifica se a fun��o Physics.Raycast retorna verdadeiro. 
Isso significa que o raio lan�ado a partir da posi��o da c�mera na dire��o para a frente da c�mera atingiu um objeto 
dentro da dist�ncia especificada (distance).

Camera.main.transform.position especifica a posi��o inicial do raio, que � a posi��o atual da c�mera no mundo 3D.

Camera.main.transform.forward especifica a dire��o na qual o raio ser� lan�ado, que � a dire��o para a frente da c�mera 
(ou seja, na dire��o para onde a c�mera est� apontando).

out hitInfo indica que o m�todo Raycast preencher� a vari�vel hitInfo com informa��es sobre o ponto de colis�o, como a posi��o 
do ponto de colis�o, a normal da 
superf�cie atingida e outras informa��es �teis.

distance � a dist�ncia m�xima que o raio pode percorrer antes de ser interrompido.

Dentro do bloco if, voc� colocaria o c�digo que deseja executar se o raio lan�ado da c�mera atingir um objeto. Por exemplo, voc� pode 
querer mover um objeto, realizar uma 
a��o espec�fica ou modificar algum estado do jogo com base na colis�o detectada.

Em resumo, esse c�digo � usado para detectar colis�es de raio em um jogo usando a c�mera principal como origem do raio e a dire��o 
para a frente da c�mera como dire��o 
do raio.*/