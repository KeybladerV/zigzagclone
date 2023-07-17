mergeInto(LibraryManager.library, {
    LogDebug: function(m) {
        var f = typeof UTF8ToString === 'function' ? UTF8ToString : Pointer_stringify;
        console.log(f(m));
    },
  
    LogWarning: function(m) {
        var f = typeof UTF8ToString === 'function' ? UTF8ToString : Pointer_stringify;
        console.warn(f(m));
    },

    LogError: function(m) {
        var f = typeof UTF8ToString === 'function' ? UTF8ToString : Pointer_stringify;
        console.error(f(m));
    }
});