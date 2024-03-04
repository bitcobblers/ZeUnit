import { component$, $, useSignal } from "@builder.io/qwik"
import Navigation from "./navigation";
import { Logo } from "./logo";
import GitHubIcon from "./git-hub-icon";
// import { Link } from "@builder.io/qwik-city";
// import { Logomark } from "./logo";

const MenuIcon = component$((props: any) => {
  return (
    <svg
      aria-hidden="true"
      viewBox="0 0 24 24"
      fill="none"
      strokeWidth="2"
      strokeLinecap="round"
      {...props}
    >
      <path d="M4 7h16M4 12h16M4 17h16" />
    </svg>
  )
})

const CloseIcon = component$((props: any) => {
  return (
    <svg
      aria-hidden="true"
      viewBox="0 0 24 24"
      fill="none"
      strokeWidth="2"
      strokeLinecap="round"
      {...props}
    >
      <path d="M5 5l14 14M19 5l-14 14" />
    </svg>
  )
});

export default component$(() => {
  const menuStyle = "flex inset-0 z-50 items-start overflow-y-auto bg-slate-900/50 pr-10 backdrop-blur"
  const isOpen = useSignal(false);
  const activeStyle = useSignal("");

  const openMenu = $(() => {
    console.log('open');
    isOpen.value = true;
    console.log(isOpen)
    activeStyle.value = menuStyle;
  });

  const closeMenu = $(() => {
    console.log('close');
    isOpen.value = true;
    console.log(isOpen)
    activeStyle.value = menuStyle + " hidden";
  });
  closeMenu();
  return (
    <>      
      <div class="relative flex w-full">        
        <button
          type="button"
          onClick$={openMenu}        
          aria-label="Open navigation"
        >        
          <MenuIcon class="h-6 w-6 stroke-slate-500" />                
        </button>
        <div class="pt-2 md:pt-4"><Logo class="flex-0 block fill-slate-700 dark:fill-sky-100 text-2xl " /></div>
      <div class="grow">flex</div>
      </div>
      <div class="pt-3 md:pt-5 md:pr-5">
        <a href="https://github.com/bitcobblers/ZeUnit/" target="_blank" class="group" aria-label="ZeUnit repository on GitHub">
          <GitHubIcon class="h-6 w-6 fill-slate-400 group-hover:fill-slate-500 dark:group-hover:fill-slate-300" />
        </a>
      </div>
      <div
        class={activeStyle}
        aria-label="Navigation"
      >
        <div class="min-h-full w-full max-w-xs bg-white px-4 pb-12 pt-5 sm:px-6 dark:bg-slate-900">
          <div class="flex items-center">
            <button
              type="button"
              onClick$={closeMenu}
              aria-label="Close navigation"
            >
              <CloseIcon class="h-6 w-6 stroke-slate-500" />
            </button>
          </div>
          <Navigation />
        </div>
      </div>
    </>
  )
});
