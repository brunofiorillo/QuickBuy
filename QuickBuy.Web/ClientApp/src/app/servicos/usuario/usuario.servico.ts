import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Usuario } from "../../modelo/usuario";

@Injectable({
  providedIn: "root"
  //significa q vai ser publicado na raiz(root) e todo o sistema pode usar
})

export class UsuarioServico {
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;  
  }

  public verificarUsuario(usuario: Usuario): Observable<Usuario> {

    const headers = new HttpHeaders().set('content-type', 'application/json');

    var body = {
      email: usuario.email,
      senha: usuario.senha
    }
    //this.baseUrl = raiz do site que pode ser exemplo.: www.quickbuy.com.br
    // return this.http.post<Usuario>(this.baseURL + "api/usuario, body, { headers });
    return this.http.post<Usuario>("http://localhost:44395/api/usuario", body, { headers });
  }
  
}
