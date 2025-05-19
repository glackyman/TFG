# TFG

### F. Javier García González

## ⚔️ Glacky`s Andventurs

    Debes recuperar la reliquia familiar, una espada de tu difunto padre
    perdida en el tiempo y el olvido al igual que el.

    En el juego te embarcarás en una aventura de exploración y algo de lucha para abrirte paso.

## IDE

- Godot Engine, como motor de juego.
- Visual Studio Code, como editor

## Mecanicas

Este apartado se dejo en el olvido... muhcas cosas ya esban hechas

- Las monedas se pueden genear de diferentes valores `1, 5 y 10`

- Ahora los PickUps se añaden al inventario del jugador

---
[![Ver gameplay](https://img.youtube.com/vi/mQKa92lbnkA/0.jpg)](https://www.youtube.com/watch?v=mQKa92lbnkA)

## 🛠️ Problemas

### [13/04/2025 - 14/04/2025] Error de sincronización con Git

- ⚠️ **Problema:** No se detectaban los cambios correctamente al hacer `git add` y `git push`.
  Probablemente era por una mala configuración del repositorio.
- ✔️ **Solución:** Se resolvió eliminando el repositorio y creándolo de nuevo.

### [26/04/2025 - 27/04/2025] Error de reproducción de animaciones

- ⚠️ **Problema:** Las animaciones de `ataque` son canceladas por `idle/movimiento`. Se plantea solucionar incluyendo una máquina de estados.
- ✔️ **Solución:** Implementación de máquina de estados básica.

- ⚠️ **Problema:** Por algún motivo, las `colisiones de las llaves` dejaron de funcionar. Puede ser algún fallo al cambiar tantas cosas después de tanto tiempo. Se plantea arreglo más adelante, cuando se vuelvan a trabajar en estos ítems.

### [03/04/2025 - 04/04/2025] Error de lógica máquina de estados

- ⚠️ **Problema:** La máquina de estados solo trabaja con animaciones laterales. Se plantea arreglar con un nodo `AnimationBlendSpace1D` o `AnimationBlendSpace2D`. Se decidirá uno tras consultar información de cada uno.
- ✔️ **Solución:** Tras buscar información, se usó un `AnimationBlendSpace1D`, ya que no requerimos de transiciones complejas entre animaciones. Tras esto, ya se pueden ejecutar las animaciones en todas las direcciones.

- ⚠️ **Problema:** Pequeño error de lógica que quedó subido a GitHub. En el flip del eje H se cometió el error al invertir la condición para el flip.
- ✔️ **Solución:** Se arregló invirtiendo este error anteriormente cometido.

### [10/05/2025 - 12/05/2025] Comportamiento enemigos y jugador

- ⚠️ **Problema:** Se descubrio un `bug en el movimiento del jugador` la animacion q se muestra es correspondiente al `primer imput` y no tiene en cuenta que se cambie, es decir si se pulsar hacia arriba y aun lado y luego se pulsa hacia arriba se queda "clavada" la animacion up en vez la de side

- ⚠️ **Problema:** Los enemigos aunque sigan al jugador lo hacen de forma continua y sin logica, ademas de que se quedan clavados entre ellos y demas, tampoco atacan.

---

## 🚀 Avances

## 🔹 Previo a las prácticas

- Se incluyeron clases base para los personajes, aunque aún falta desarrollar lógica compleja.
- Se implementó el **movimiento del jugador** junto con sus **animaciones**.
- Se crearon varios tipos de objetos interactivos como:
  - Llaves
  - Monedas
  - Árboles
  (_falta terminar su lógica_)
- Se hicieron los **primeros diseños de mapas**.

## 🔹 Durante las prácticas

- ### Semana 1-3

  - Se modificaron sprites y se rehicieron animaciones.
    - Se añadió la posibilidad de atacar.
  - Se empezaron a desarrollar las primeras colisiones de las llaves, monedas y árboles.
  - Se creó una escena con un suelo con colisiones, un árbol, una llave y una moneda. El personaje y el entorno parecen responder correctamente (salvo las llaves).

- ### Semana 4

  - Máquina de estados básica agregada.

  - Se agregó complejidad a la máquina de estados.

- ### Semana 5

  - Se añadio una clase Enemy
    - Con sus propiedades
    - 2 clases, por ahora. La extienden; Troles y Enanos.
    - Se empezaron hacer las primeras pruebas de seguimiento al jugador
    - Los enemigos se generan las escenas de forma preterminada, esta por ver en tiempo de ejecucion
  - Debido a la falta de sprites en Top-Down de enemigos que cumplan con los requisitos que busco, usaré el mismo sprite del jugador pero tintado de colores segun el enemigo, por ejemplo verde para los Trol y rojo para los Enanos.

- ### Semana 6

  - Se termino la logica de los objetos (salvo su uso), ahora ya se eliminan al recogerse y se añaden al inventario del jugador, se utilizan las misma señales de siempre.

  - Muerte de enemigos.

  -Menu muy basico.

---

## ✅ Lista de tareas (por ampliar)

- 🛠️ **Máquinas de estados**
  - [x] Jugador: Implementar máquina de estados para controlar animaciones y comportamientos del jugador.
  - [ ] Enemigos: Implementar máquina de estados para controlar los comportamientos de los enemigos.

- 🛠️ **Colisiones completadas**
  - [x] Jugador/Enemigos: Finalizar la lógica de colisiones entre personajes y objetos.
  - [x] Las señales ya funciona!.
  - [x] Los enemigos mueren

- 🛠️ **Desarrollo de mapa**
  - [ ] Completar los diseños de los primeros mapas jugables.
  - [ ] Agregar puntos de interacción (puertas, objetos, etc.).

- 🛠️ **Primeras mazmorras**
  - [ ] Desarrollar la lógica básica de las primeras mazmorras.
  - [ ] Crear los primeros enemigos de mazmorras y sus comportamientos.

- 🛠️ **Lógica de enemigos**
  - [ ] Programar el comportamiento de los enemigos en combate y patrullaje.

- 🛠️ **Generación procedural de mazmorras**
  - [ ] Implementar un sistema de generación procedural de mazmorras.

- 🛠️ **Objetos**

  - [x] Su logica esta finalizada y tienen un buen ciclo de vida. Son eliminadas mediante `QueueFree`

- 🛠️ **Objetos**

  -[x] Menú extremadmente basico pero funcional

## 🧠 Ideas

- Pensé en que para el objetivo final haga falta avanzar en equipo. Una idea de un juego es que exploras las cuevas hasta tu nivel y luego vendes todo lo que ganas. Con eso compras y mejoras equipo nuevo.

- No tengo claro la generación de las cuevas, si de forma procedural por partida o cada vez que las explores.
