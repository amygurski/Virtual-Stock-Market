export default {
  methods: {
    formatCurrency(num) {
      let isPositive = num < 0 ? false : true;

      if (isPositive) {
        return '$' + num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
      } else {
        num = Math.abs(num);
        return '-$' + num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
      }
    },
    formatDateOnly(dateString) {
      let rawDate = new Date(Date.parse(dateString));
      let options = { year: 'numeric', month: '2-digit', day: '2-digit' };
      return new Intl.DateTimeFormat(navigator.language, options).format(
        rawDate
      );
    },
    formatDateAndTime(dateString) {
      let rawDate = new Date(Date.parse(dateString));
      let options = { year: 'numeric', month: '2-digit', day: '2-digit', hour: '2-digit', minute: '2-digit' };
      return new Intl.DateTimeFormat(navigator.language, options).format(
        rawDate
      );
    }
  }
};
