$(function () {
  $('#EventStartDate').pickadate({
    monthsFull: ['Січень', 'Лютий', 'Березень', 'Квітень', 'Травень', 'Червень', 'Липень', 'Серпень', 'Вересень', 'Жовтень', 'Листопад', 'Грудень'],
    monthsShort: ['Січ', 'Лют', 'Бер', 'Квіт', 'Трав', 'Черв', 'Лип', 'Серп', 'Вер', 'Жовт', 'Лист', 'Груд'],
    weekdaysFull: ['Неділя', 'Понеділок', 'Вівторок', 'Середа', 'Четвер', 'П\'ятниця', 'Субота'],
    weekdaysShort: ['Нд', 'Пон', 'Вт', 'Сер', 'Четв', 'Пт', 'Суб'],
    showMonthsShort: undefined,
    showWeekdaysFull: undefined,

    // Buttons
    today: 'Сьогодні',
    clear: 'Очистити',

    // Formats
    format: 'dd.mm.yyyy',
    formatSubmit: undefined,
    hiddenPrefix: undefined,
    hiddenSuffix: '_submit',

    //min date
    min: new Date()
  });
  $('#EventStartTime').pickatime({
    format: 'H:i'
  });
});