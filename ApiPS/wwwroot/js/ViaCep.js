document.addEventListener('DOMContentLoaded', () => {
    const cep = document.getElementById('cep');
    const logradouro = document.getElementById('logradouro');
    const cidade = document.getElementById('cidade');
    const estado = document.getElementById('estado');

    cep.addEventListener('focusout', async () => {
        const onlyNumbers = /^[0-9]{8}$/;

        // Validação do CEP
        if (!onlyNumbers.test(cep.value)) {
            alert('CEP INVÁLIDO');
            return;
        }

        try {
            const response = await fetch(`https://viacep.com.br/ws/${cep.value}/json/`);

            if (!response.ok) {
                throw new Error('Erro ao buscar informações do CEP');
                logradouro.value = null;
                cidade.value = null;
                estado.value = null;

            }

            const responseCep = await response.json();

            if (responseCep.erro) {
                throw new Error('CEP não encontrado');
                logradouro.value = null;
                cidade.value = null;
                estado.value = null;

            }

            // Preenchendo os campos
            logradouro.value = responseCep.logradouro;
            cidade.value = responseCep.localidade;
            estado.value = responseCep.uf;
        } catch (error) {
            console.error(error);
            alert(error.message);
        }
    });
});
