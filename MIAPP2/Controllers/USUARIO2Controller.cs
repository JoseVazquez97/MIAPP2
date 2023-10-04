using iTextSharp.text;
using iTextSharp.text.pdf;
using MIAPP2.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MIAPP2.Controllers
{
    public class USUARIO2Controller : Controller
    {
        #region LOGIN
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult ObtenerGrillaCancha()
        {
            // Lógica para obtener los datos de la grilla (por ejemplo, desde la base de datos)
            using (var contexto = new PARTIDOSYAEntities())
            {
                var usuarios = contexto.USUARIO2.Where(x => x.Usuario2Tipo == "C").ToListAsync();

                // Devuelve la vista parcial de la grilla con los datos
                return PartialView("_GrillaCancha", usuarios);
            }
        }

        [HttpPost]
        public ActionResult ObtenerGrillaUsuarios()
        {
            // Lógica para obtener los datos de la grilla (por ejemplo, desde la base de datos)
            using (var contexto = new PARTIDOSYAEntities())
            {
                var usuarios = contexto.USUARIO2.Where(x=> x.Usuario2Tipo == "J").ToListAsync();

                // Devuelve la vista parcial de la grilla con los datos
                return PartialView("_GrillaUsuarios", usuarios);
            }
        }


        [HttpPost]
        public ActionResult Index(string Usuario2Nick, string Usuario2Pass)
        {
            USUARIO2 usuariox = VerificarUsuario(Usuario2Nick, Usuario2Pass);

            if (usuariox != null)
            {
                Session["UserId"] = usuariox.Usuario2ID.ToString();
                Session["UserNick"] = usuariox.Usuario2Nick;
                Session["UserTipo"] = usuariox.Usuario2Tipo;
                return RedirectToAction("Home", "USUARIO2");
            }

            return View();
        }

        private USUARIO2 VerificarUsuario(string Usuario2Nick, string Usuario2Pass)
        {
            using (var contexto = new PARTIDOSYAEntities())
            {
                var usuario = contexto.USUARIO2.FirstOrDefault(u => u.Usuario2Nick == Usuario2Nick && u.Usuario2Pass == Usuario2Pass);

                if (usuario != null)
                {
                    return usuario;
                }
            }

            return null;
        }
        #endregion

        #region HOME

        public ActionResult Home()
        {
            using (var contexto = new PARTIDOSYAEntities())
            {
                return View(contexto.USUARIO2.ToList());
            }
        }

        [HttpGet]
        public ActionResult Home(string filtroUsuario2Nick, string filtroCanchaNick)
        {
            List<USUARIO2> jugadoresEncontrados = new List<USUARIO2>();
            List<USUARIO2> canchasEncontradas = new List<USUARIO2>();
            List<USUARIO2> listaFinal = new List<USUARIO2>();

            if (!string.IsNullOrEmpty(filtroUsuario2Nick) || !string.IsNullOrEmpty(filtroCanchaNick))
            {
                using (var contexto = new PARTIDOSYAEntities())
                {
                    if (!string.IsNullOrEmpty(filtroUsuario2Nick))
                    {
                        jugadoresEncontrados = contexto.USUARIO2.Where(x => x.Usuario2Nick.Contains(filtroUsuario2Nick)).ToList();
                    }
                    else
                    {
                        jugadoresEncontrados = contexto.USUARIO2.Where(x => x.Usuario2Tipo == "J").ToList();
                    }

                    if (!string.IsNullOrEmpty(filtroCanchaNick))
                    {
                        canchasEncontradas = contexto.USUARIO2.Where(x => x.Usuario2Nick.Contains(filtroCanchaNick)).ToList();
                    }
                    else
                    {
                        canchasEncontradas = contexto.USUARIO2.Where(x => x.Usuario2Tipo == "C").ToList();
                    }

                    foreach (var x in jugadoresEncontrados)
                    {
                        listaFinal.Add(x);
                    }

                    foreach (var x in canchasEncontradas)
                    {
                        listaFinal.Add(x);
                    }

                    return View(listaFinal);
                }
            }

            using (var contexto = new PARTIDOSYAEntities())
            {
                return View(contexto.USUARIO2.ToList());
            }
        }
        #endregion

        #region REGISTRO
        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registro(USUARIO2 newUser)
        {
            try
            {
                using (var contexto = new PARTIDOSYAEntities())
                {
                    newUser.Usuario2Status = "O";
                    newUser.Usuario2Estado = "A";
                    newUser.Usuario2Fecha = "-";
                    contexto.USUARIO2.Add(newUser);
                    contexto.SaveChanges();
                }


                string sessionID = (string)Session["UserId"];

                if (sessionID != null)
                {
                    return RedirectToAction("Home");
                }
                else 
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region PERFIL_AGENO
        [HttpGet]
        public ActionResult PerfilAgeno(long id)
        {
            using (var contexto = new PARTIDOSYAEntities())
            {
                USUARIO2 USUARIO = BuscarUsuarioPorID(id);
                return View(USUARIO);
            }

        }
        #endregion

        #region PERFIL_ADMIN

        [HttpGet]
        public ActionResult PerfilAdmin(long? idExtra)
        {
            if (idExtra.HasValue)
            {
                long id = idExtra.Value;

                using (var contexto = new PARTIDOSYAEntities())
                {
                    USUARIO2 usuario = BuscarUsuarioPorID(id);
                    return View("PerfilAdmin", usuario);
                }
            }

            return RedirectToAction("Home", "USUARIO2");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PerfilAdmin(USUARIO2 usuario)
        {
            if (ModelState.IsValid)
            {
                using (var contexto = new PARTIDOSYAEntities())
                {
                    USUARIO2 registro = usuario;

                    contexto.Entry(registro).State = EntityState.Modified;
                    contexto.SaveChanges();
                }

                return RedirectToAction("Home");
            }

            return View(usuario);
        }
        #endregion  

        #region PERFIL_SESSION
        [HttpGet]
        public ActionResult Perfil()
        {

             return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Perfil(USUARIO2 usuario)
        {
            if (ModelState.IsValid)
            {
                using (var contexto = new PARTIDOSYAEntities())
                {
                    USUARIO2 registro = usuario;

                    contexto.Entry(registro).State = EntityState.Modified;
                    contexto.SaveChanges();
                }

                return RedirectToAction("Home");
            }

            return View(usuario);
        }
        #endregion

        #region RECUPERACION

        public ActionResult Recuperacion()
        {
            using (var contexto = new PARTIDOSYAEntities())
            {
                return View(contexto.USUARIO2.Where(x => x.Usuario2Estado == "F").ToList());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Recuperacion(long id)
        {
            using (var contexto = new PARTIDOSYAEntities())
            {
                var usuario = contexto.USUARIO2.Find(id);

                if (usuario != null)
                {
                    usuario.Usuario2Estado = "A"; 
                    contexto.SaveChanges();
                }
            }

            return RedirectToAction("Home");
        }

        #endregion

        #region ELIMINAR
        public ActionResult Eliminar(long id)
        {
            using (var contexto = new PARTIDOSYAEntities())
            {
                var usuario = contexto.USUARIO2.Find(id);
                if (usuario != null)
                {
                    return View(usuario);
                }
            }

            return RedirectToAction("Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            using (var contexto = new PARTIDOSYAEntities())
            {
                var usuario = contexto.USUARIO2.Find(id);

                if (usuario != null)
                {
                    usuario.Usuario2Estado = "F";
                    contexto.SaveChanges();
                }
            }
            
            return RedirectToAction("Home");
        }
        #endregion

        #region FUNCIONES PRIVADAS
        private USUARIO2 BuscarUsuarioPorID(long id) 
        {
            USUARIO2 usuario = new USUARIO2();

            using (var contexto = new PARTIDOSYAEntities())
            {
                usuario = contexto.USUARIO2.Find(id);
                if (usuario != null)
                {
                    return usuario;
                }
            }

            return null;
        }
        #endregion

        #region EXPORTAR A PDF
        public ActionResult ExportarPDF()
        {
            // Obtener los datos de las canchas desde tu fuente de datos (por ejemplo, base de datos)
            List<USUARIO2> canchas = ObtenerCanchas();

            // Crear el documento PDF
            MemoryStream ms = new MemoryStream();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
            document.Open();

            // Agregar el contenido de la tabla de canchas al documento PDF
            PdfPTable table = new PdfPTable(2); // Ajusta el número de columnas según tu estructura de datos
            foreach (var cancha in canchas)
            {
                table.AddCell(cancha.Usuario2Nick);

                if (cancha.Usuario2Status == "O")
                {
                    table.AddCell("NO HAY TURNOS DISPONIBLES");
                }
                else 
                {
                    table.AddCell("HAY TURNOS DISPONIBLES");
                }
                
            }
            document.Add(table);

            document.Close();

            // Descargar el PDF generado
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=Canchas.pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();

            return null;
        }

        // Método de ejemplo para obtener las canchas desde una fuente de datos
        private List<USUARIO2> ObtenerCanchas()
        {
            List<USUARIO2> canchas = new List<USUARIO2>();

            using (var contexto = new PARTIDOSYAEntities())
            {

                canchas = contexto.USUARIO2.Where(x => x.Usuario2Tipo == "C").ToList();
            }
            
            return canchas;
        }

        // Clase de ejemplo para representar una Cancha
        public class Cancha
        {
            public string Nombre { get; set; }
            public string Disponibilidad { get; set; }
        }

        #endregion
    }
}
