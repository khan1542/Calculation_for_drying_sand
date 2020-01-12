// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var ctx = document.getElementById('myChart').getContext('2d');
var chart = new Chart(ctx, {
    // The type of chart we want to create
    type: 'pie',

    // The data for our dataset
    data: {
        labels: ['Q1', 'Q2', 'Q3', 'Q4', 'Q5'],
        datasets: [
            {
                label: 'My First dataset',
                name:"smth",
                backgroundColor: ['#1968e6', '#7463e6', '#f52222', '#16de1d', '#3cf0d5'],
                data: [42.9, 33.1, 2, 10, 11.9],
            }]
        },
});