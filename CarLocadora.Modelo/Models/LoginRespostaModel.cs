namespace CarLocadora.Models.Models

{
    public class LoginRespostaModel
    {
        public bool Autenticado { get; set; }
        public string Usuario { get; set; }
        public DateTime? DataExpiracao { get;  set; }
        public string Token { get;  set; }
    }
}