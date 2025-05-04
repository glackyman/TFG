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

_(a completar)_

---

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

---

## ✅ Lista de tareas (por ampliar)

- 🛠️ **Máquinas de estados**
  - [x] Jugador: Implementar máquina de estados para controlar animaciones y comportamientos del jugador.
  - [ ] Enemigos: Implementar máquina de estados para controlar los comportamientos de los enemigos.

- 🛠️ **Colisiones completadas**
  - [ ] Jugador/Enemigos: Finalizar la lógica de colisiones entre personajes y objetos.

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

## 🧠 Ideas

- Pensé en que para el objetivo final haga falta avanzar en equipo. Una idea de un juego es que exploras las cuevas hasta tu nivel y luego vendes todo lo que ganas. Con eso compras y mejoras equipo nuevo.

- No tengo claro la generación de las cuevas, si de forma procedural por partida o cada vez que las explores.
