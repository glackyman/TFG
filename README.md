# TFG

### F. Javier García González

## ⚔️ Glacky`s Andventurs

    Debes recuperar la reliquia familiar, una espada de tu difunto padre
    perdida en el tiempo y el olvido al igual que el.

    En el juego te embarcaras en una aventura de exploración y algo de lucha para abrirte paso

## IDE

- Godot Engine
- Visual Studio Code
- Visual Studio 2022

## Mecanicas

_(a completar)_

---

## 🛠️ Problemas

### [13/04/2025 - 14/04/2025] Error de sincronización con Git

- ⚠️ **Problema:** No se detectaban los cambios correctamente al hacer `git add` y `git push`.  
  Probablemente era por una mala configuración del repositorio.
- ✔️ **Solución:** Se resolvió eliminando el repositorio y creándolo de nuevo

### [26/04/2025 - 27/04/2025] Error de reproduccion de animaciones

- ⚠️ **Problema:** Las animaciones de `ataque` son canceladas por `idle/movimiento` se plantea solucionar inlcuyendo una maquina de estados.

- ⚠️ **Problema:** Por algun motivo las `colsiones de las llaves` dejaron de funcionar, puede ser algun fallo de cambiar tantas cosas despues de tanto tiempo, se plantea arreglo mas adelante, cuando se vuelvan a trabajar en estos items.

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

- Se modificaron sprites y se reicieron animaciones
  - se añadio la posibilidad de atacar
- Se emepezaron a desarollar las primeras colisiones de las llaves, monedas y arboles
- Se creo una escena con un suelo, con colisiones. Un arbol una llave y una moneda, el personaje y el entorno parece responder correctamente.(salvo las llaves)

---

## ✅ Lista de tareas (por ampliar)

- 🛠️ **Máquinas de estados**
  - [ ] Jugador: Implementar máquina de estados para controlar animaciones y comportamientos del jugador.
  - [ ] Enemigos: Implementar máquina de estados para controlar los comportamientos de los enemigos.

- 🛠️ **Colisiones completadas**
  - [ ] Jugador/Enemigos: Finalizar la lógica de colisiones entre personajes y objetos.
  
- 🛠️ **Desarrollo de mapa**
  - [ ] Completar los diseños de los primeros mapas jugables.
  - [ ] Agregar puntos de interacción (puertas, objetos, etc.).

- 🛠️ **Primera mazmorras**
  - [ ] Desarrollar la lógica básica de las primeras mazmorras.
  - [ ] Crear los primeros enemigos de mazmorras y sus comportamientos.

- 🛠️ **Lógica de enemigos**
  - [ ] Programar el comportamiento de los enemigos en combate y patrullaje.
  
- 🛠️ **Generación procedural de mazmorras**
  - [ ] Implementar un sistema de generación procedural de mazmorras.
