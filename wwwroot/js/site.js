$(document).ready(function () {

    $('.view-more-btn').on('click', function (e) {


        var card = $(this).closest('.car-card');


        var make = card.data('make');
        var model = card.data('model');
        var year = card.data('year');
        var carClass = card.data('class');
        var transmission = card.data('transmission');
        var drive = card.data('drive');
        var fuel = card.data('fuel');


        $('#modalTitle').text(make + ' ' + model);

        var modalContent = `
                            <p><strong>Year:</strong> ${year}</p>
                            <p><strong>Class:</strong> ${carClass}</p>
                            <p><strong>Transmission:</strong> ${transmission}</p>
                            <p><strong>Drive:</strong> ${drive}</p>
                            <p><strong>Fuel:</strong> ${fuel}</p>
                        `;
        $('#modalBody').html(modalContent);

        var carModal = new bootstrap.Modal(document.getElementById('carModal'));
        carModal.show();
    });
});

