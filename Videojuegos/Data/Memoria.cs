using Microsoft.Extensions.Caching.Memory;

namespace VideojuegosWebAPI.Data
{
    public class Memoria
    {
        private readonly IMemoryCache _memoryCache;

        public Memoria(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        //Obtiene la lista de valores de videojuegos
        public List<Models.VideoJuegos> ObtenerVideoJuegos()
        {
            List<Models.VideoJuegos> listaVideoJuegos;
            if (_memoryCache.Get("ListaVideoJuegos") is null)
            {
                listaVideoJuegos = new List<Models.VideoJuegos>();
                _memoryCache.Set("ListaVideoJuegos", listaVideoJuegos);
            }
            else
            {
                listaVideoJuegos = (List<Models.VideoJuegos>)_memoryCache.Get("ListaVideoJuegos");
            }
            return listaVideoJuegos;
        }
        //Guarda el video juego en una memoria persistente
        public void GuardarVideoJuego(Models.VideoJuegos videoJuego)
        {
            List<Models.VideoJuegos> listaVideoJuegos;
            listaVideoJuegos = ObtenerVideoJuegos();
            listaVideoJuegos.Add(videoJuego);

            foreach (var item in videoJuego.Tipo_De_Juego)
            {
                GuardarTipoVideoJuego(item);
            }

        }
        //Obtiene los videoJuegos por el id seleccionado
        public Models.VideoJuegos ObtenerVideoJuegoID(int id)
        {
            List<Models.VideoJuegos> listaVideoJuegos = ObtenerVideoJuegos();
            Models.VideoJuegos juegos = new Models.VideoJuegos();
            foreach (var videoJuego in listaVideoJuegos)
            {
                if (videoJuego.Id_Juego == id)
                {
                    juegos = videoJuego;
                    break;
                }
            }
            return juegos;
        }
        //Borra el videojuego con el id seleccionado
        public void BorrarVideoJuego(Models.VideoJuegos videoJuego, int id)
        {
            List<Models.VideoJuegos> listaVideoJuego = ObtenerVideoJuegos();

            listaVideoJuego.RemoveAll(e => e.Id_Juego == videoJuego.Id_Juego);

            _memoryCache.Set("ListaVideoJuegos", listaVideoJuego);
        }

        //Borra el tipo de videojuego asignado a videojuego con el id seleccionado
        public void BorrarTipoVideoJuegoLista(Models.VideoJuegos videoJuego, int id, int idTipo)
        {
            List<Models.VideoJuegos> listaVideoJuego = ObtenerVideoJuegos();
            foreach (var item in listaVideoJuego)
            {
                if (item.Id_Juego == id)
                {
                    for (int i = 0;i < item.Tipo_De_Juego.Count;i++)
                    {
                        if (item.Tipo_De_Juego[i].Id_Tipo_Juego == idTipo)
                        {
                            item.Tipo_De_Juego.RemoveAt(i);
                        }
                    }
                }
            }

            listaVideoJuego.RemoveAll(e => e.Id_Juego == videoJuego.Id_Juego);

            _memoryCache.Set("ListaVideoJuegos", listaVideoJuego);
        }
        //Edita los videojuegos por ID
        public void EditarVideoJuego(Models.VideoJuegos videoJuegos, int id)
        {
            List<Models.VideoJuegos> listaVideoJuegos = ObtenerVideoJuegos();

            Models.VideoJuegos videoJuegoModificar = listaVideoJuegos.FirstOrDefault(e => e.Id_Juego == id);


            if (videoJuegoModificar != null)
            {
                // Actualiza los valores del videojuego encontrado
                videoJuegoModificar.Id_Juego = videoJuegos.Id_Juego;
                videoJuegoModificar.Serial_Number = videoJuegos.Serial_Number;
                videoJuegoModificar.Año_Publicacion = videoJuegos.Año_Publicacion;
                videoJuegoModificar.Casa_Fabricante = videoJuegos.Casa_Fabricante;
                videoJuegoModificar.Tipo_De_Juego = videoJuegos.Tipo_De_Juego;

                // Guarda la lista actualizada en la memoria caché
                _memoryCache.Set("ListaVideoJuegos", listaVideoJuegos);
            }
        }

        //Procesamiento del tipo de juegos
        public List<Models.Tipo_De_Juego> ObtenerTipoVideoJuegos()
        {
            List<Models.Tipo_De_Juego> listaTipoVideoJuegos;
            if (_memoryCache.Get("ListaTipoVideoJuegos") is null)
            {
                listaTipoVideoJuegos = new List<Models.Tipo_De_Juego>();
                _memoryCache.Set("ListaTipoVideoJuegos", listaTipoVideoJuegos);
            }
            else
            {
                listaTipoVideoJuegos = (List<Models.Tipo_De_Juego>)_memoryCache.Get("ListaTipoVideoJuegos");
            }
            return listaTipoVideoJuegos;
        }
        //Guarda el tipo de video juego en una memoria persistente
        public void GuardarTipoVideoJuego(Models.Tipo_De_Juego tipoVideoJuego)
        {
            List<Models.Tipo_De_Juego> listaTipoVideoJuegos;
            listaTipoVideoJuegos = ObtenerTipoVideoJuegos();
            listaTipoVideoJuegos.Add(tipoVideoJuego);
        }
        //Obtiene los tipos de videoJuegos por el id seleccionado
        public Models.Tipo_De_Juego ObtenerTipoVideoJuegoID(int id)
        {
            List<Models.Tipo_De_Juego> listaTipoVideoJuegos = ObtenerTipoVideoJuegos();
            Models.Tipo_De_Juego tipoJuegos = new Models.Tipo_De_Juego();
            foreach (var videoJuego in listaTipoVideoJuegos)
            {
                if (videoJuego.Id_Tipo_Juego == id)
                {
                    tipoJuegos = videoJuego;
                    break;
                }
            }
            return tipoJuegos;
        }
        //Borra el tipo de videojuego con el id seleccionado
        public void BorrarTipoVideoJuego(Models.Tipo_De_Juego tipoVideoJuego, int id)
        {
            List<Models.Tipo_De_Juego> listaTipoVideoJuego = ObtenerTipoVideoJuegos();

            listaTipoVideoJuego.RemoveAll(e => e.Id_Tipo_Juego == tipoVideoJuego.Id_Tipo_Juego);

            _memoryCache.Set("ListaTipoVideoJuegos", listaTipoVideoJuego);
        }
        //Edita los tipos de videojuegos por ID
        public void EditarTipoVideoJuego(Models.Tipo_De_Juego tipoVideoJuegos, int id)
        {
            List<Models.Tipo_De_Juego> listaTipoVideoJuego = ObtenerTipoVideoJuegos();

            Models.Tipo_De_Juego tipoVideoJuegoModificar = listaTipoVideoJuego.FirstOrDefault(e => e.Id_Tipo_Juego == id);


            if (tipoVideoJuegoModificar != null)
            {
                // Actualiza los valores del tipo de video juego encontrado
                tipoVideoJuegoModificar.Id_Tipo_Juego = tipoVideoJuegos.Id_Tipo_Juego;
                tipoVideoJuegoModificar.Descripcion = tipoVideoJuegos.Descripcion;

                // Guarda la lista actualizada en la memoria caché
                _memoryCache.Set("ListaTipoVideoJuegos", listaTipoVideoJuego);
            }
        }
    }
}