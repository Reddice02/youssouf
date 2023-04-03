
            /*async function getdata(_url) {

                let resp = await fetch(_url, {
                           method: 'GET',
                           headers: {
                               'Accept': 'application/json'
                           }
                });

                let result = await resp.json();
                return result;

            }

            async function getonedata(_url,id) {

                     let resp = await fetch(_url+"/"+id, {
                     method: 'GET',
                     headers: {
                               'Accept': 'application/json'
                              }
                     });

                     let result = await resp.json();

                     return result;

            }

            async function deletedata(_url,id) {

                console.log(_url,id);
                choix = confirm("Voulez vous vraiment supprimer cet element ?");

                if (choix) {
                    fetch(_url + "/" + id, {
                        method: 'DELETE'
                    });
                    alert("Cet élément a été supprimé ");
                }
                else {
                    alert("la suppression a été annulée");
                }
                

            }


            function postdata(_url,data) {
                
                fetch(_url, {
                    method: 'POST',
                    headers: {
                        'content-type': 'application/json'
                    },
                    body:  JSON.stringify(data)
                });

            }

            function putdata(_url, data, id) {

                fetch(_url + "/" + id, {
                    method: 'PUT',
                    headers: {
                        'content-type': 'application/json'
                    },
                    body: JSON.stringify(data)
                });

            }

            function edit(id) {
                sessionStorage.setItem('edition', id);
                //window.location.replace('http://sidanmor.com');
            }*/

            function postdata(_url) {

                var form = document.querySelector('form');
                var data = new FormData(form);

                console.log(data);

                /*fetch(_url, {
                    method: 'POST',
                    headers: {
                        'content-type': 'application/json'
                    },
                    body: JSON.stringify(data)
                });*/

            }

            function retour(lien) {
                location.replace('https://localhost:7135/' + lien);
            }

            function modifier(id, lien){
                sessionStorage.setItem("modif", id);
                location.replace('https://localhost:7135/' + lien);
            }

            function detail(id, lien) {
                sessionStorage.setItem("detail", id);
                location.replace('https://localhost:7135/' + lien);
            }

            function supprimer(_url,id,lien){
                sessionStorage.setItem("supp", id);
                let choix = confirm("Voulez vous vraiment supprimer cet élement ?");

                    console.log(_url, id, lien);

                if (choix) {
                        fetch(_url + "?id=" + id, {
                            method: 'DELETE'
                        });
                        alert("Cet élément a été supprimé ");
                        location.replace('https://localhost:7135/' + lien);
}
                else {
                    alert("la suppression a été annulée");
                    location.replace('https://localhost:7135/' + lien);
                    }
            }