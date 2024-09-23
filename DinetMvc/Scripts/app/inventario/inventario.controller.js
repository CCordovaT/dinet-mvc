class InventarioController {

    constructor() {

        this.listarInventarios();
        this.modal = new bootstrap.Modal(document.getElementById('exampleModal'));

        document.addEventListener('inventarioGuardado', this.onInventarioGuardado.bind(this));

    }

    listarInventarios() {

        fetch(`${window.location.origin}/inventario/lista`)
            .then(response => response.text())
            .then(data => {

                document.getElementById('listaInventario').innerHTML = data;

            })

    }

    onBtnNuevoClick() {

        fetch(`${window.location.origin}/inventario/formulario`)
            .then(response => response.text())
            .then(data => {

                document.querySelector('#exampleModal .modal-body').innerHTML = data;
                this.modal.show();

            });

    }

    onInventarioGuardado(event) {

        this.modal.hide();
        this.listarInventarios();

    }

    onBtnBuscar() {

        const fechaInicio = document.getElementById('txtFechaInicio').value;
        const fechaFin = document.getElementById('txtFechaFin').value;
        const nroDocumento = document.getElementById('txtDocumento').value;
        const tipoDocumento = document.getElementById('txtTipoDoc').value;

        fetch(`${window.location.origin}/inventario/fechas?fechaInicio=${fechaInicio}&fechaFin=${fechaFin}&tipoMovimiento=${tipoDocumento}&nroDocumento=${nroDocumento}`)
            .then(response => response.text())
            .then(data => {

                document.getElementById('listaInventario').innerHTML = data;

            })

    }

}

const inventarioFormularioController = new InventarioFormularioController();
const inventarioController = new InventarioController();