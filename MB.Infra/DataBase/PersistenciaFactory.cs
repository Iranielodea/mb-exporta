namespace MB.Infra.DataBase
{
    public class PersistenciaFactory
    {
        public Persistencia Instanciar()
        {
            return new PersistenciaDapper();
        }
    }
}
