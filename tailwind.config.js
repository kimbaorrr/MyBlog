/** @type {import('tailwindcss').Config} */
module.exports = {
    darkMode: 'class',
    content: [
        './Pages/**/*.{html,cshtml}',
        './Views/**/*.{html,cshtml}',
        './Views/**/**/*.{html, cshtml}',
        './wwwroot/**/*.html',
        './Areas/Admin/Views/**/*.{html,cshtml}',
        './Areas/Admin/Views/**/**/*.{html,cshtml}'
    ],
    theme: {
        extend: {
            colors: {
                dark: "#0A0A0A",
            },
            fontFamily: {
                sans: ['Cabin', 'sans-serif'],
            },
        },
    },
    plugins: [],
}

