# Laboratorul 2

⚫ Ce este un viewport?

- Partea de ecran pe care se va desena.

⚫ Ce reprezintă conceptul de frames per seconds din punctul de
vedere al bibliotecii OpenGL?

- Numărul de cadre care se încarcă într-o secundă

⚫ Când este rulată metoda OnUpdateFrame()?

- După OnResize()
⚫ Ce este modul imediat de randare?

- Reprezintă 1 apel de funcție pentru fiecare obiect desenat
  
⚫ Care este ultima versiune de OpenGL care acceptă modul imediat?

- 3.5
⚫ Când este rulată metoda OnRenderFrame()?

- După OnUpdateFrame()

⚫ De ce este nevoie ca metoda OnResize() să fie executată cel puțin
o dată?

- Deoarece viewportul trbuie redimensionat conform dimensiunii date
⚫ Ce reprezintă parametrii metodei
CreatePerspectiveFieldOfView() și care este domeniul de valori
pentru aceștia?

- fovy - creează unghiul câmpului vizual în direcția y
       - în radiani, deci domeniul de valori este între 0 și 2*pi
- aspect - raportul lățime / înălțime al câmpului vizual
- zNear și zFar - distanțe
- result - o matrice de proiecție care transformă spațiul din cadrul camerei în spațiu raster
