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


# Laboratorul 3

⚫ Care este ordinea de desenare a vertexurilor pentru aceste metode(orar sau anti-orar)?

- Anti-orar

⚫ Ce este anti-aliasing? Prezentați această tehnică pe scurt.

- Anti-aliasing este o tehnică prin care se poate îmbunătății aspectul unei imagini cu o rezoluție mare la o rezoluție mai mică.

⚫ Care este efectul rulării comenzii GL.LineWidth(float)?
- Setează grosimea liniei ce urmează a fi desenată
⚫ Dar pentru GL.PointSize(float)?
- Setează mărimea punctului ce urmează a fi desenat
⚫ Funcționează în interiorul unei zone GL.Begin()?
- Nu

⚫ Care este efectul utilizării directivei LineLoop atunci când sunt desenate segmente de dreaptă multiple în OpenGL?
- Se vor desena niște linii conectate, ultimul vârf fiind conectat cu primul
⚫ Care este efectul utilizării directivei LineStrip atunci când
desenate segmente de dreaptă multiple în OpenGL?
- Se vor desena niște linii conectate, toate vârfurile în afară de primele două fiind conectate
⚫ Ce reprezintă un gradient de culoare? Cum se obține acesta în
OpenGL?
- Un gradient este o progresie graduală de culori și nuanțe, de regulă de la o culoare la o altă culoare sau de la o nuanță la o altă nuanță ale aceleiași culori. Se obține în OpenGL prin setarea unei culori diferite pentru fiecare vârf.
