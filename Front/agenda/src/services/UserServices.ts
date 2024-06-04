
import http from './http';


export default class UsuarioService {

    getAll() {
        return http.get('api/users/get-all');
    }

    save(usuario: any) {
        return http.post('api/users/create',usuario)
    }

    update(usuario: any){
        return http.put('api/users/update', usuario)
    }
}
