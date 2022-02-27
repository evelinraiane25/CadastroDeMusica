using CadastroDeMusicas.Interfaces;
using System.Collections.Generic;

namespace CadastroDeMusicas.Classes
{
    public class MusicaRepositorio : IRepositorio<Musica>
    {
        private List<Musica> _listaMusica = new List<Musica>();

        public void Atualiza(int id, Musica musica)
        {
            _listaMusica[id] = musica;
        }

        public void Exclui(int id)
        {
            _listaMusica[id].Exclui();
        }

        public void Insere(Musica musica)
        {
            _listaMusica.Add(musica);
        }

        public List<Musica> Lista()
        {
            return _listaMusica;
        }

        public int ProximoId()
        {
            return _listaMusica.Count;
        }

        public Musica RetornarPorId(int id)
        {
            return _listaMusica[id];
        }
    }
}