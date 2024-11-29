export function matchMedia(query) {
    return window.matchMedia && window.matchMedia(query).matches;
}

export function setBootstrapTheme(theme) {
    document.body.dataset['bsTheme'] = theme;
}
